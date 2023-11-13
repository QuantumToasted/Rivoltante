using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public class RevoltRestApiClient(JsonSerializerOptions serializerOptions, ILogger<RevoltRestApiClient> logger, Token token, IRevoltRestRateLimitHandler rateLimitHandler)
    : IRevoltRestApiClient
{
    public ILogger Logger { get; } = logger;

    public Token Token { get; } = token;

    public IRevoltRestRateLimitHandler RateLimitHandler { get; } = rateLimitHandler;

    public async ValueTask RequestAsync(HttpMethod method, string route, ApiModel? model = null,
        CancellationToken cancellationToken = default)
    {
        model?.Validate();
        await using var stream = await InternalRequestAsync(method, route, model, cancellationToken).ConfigureAwait(false);
    }

    public async ValueTask<TModel> RequestAsync<TModel>(HttpMethod method, string route, ApiModel? model = null, 
        CancellationToken cancellationToken = default) where TModel : ApiModel
    {
        model?.Validate();

        await using var stream = await InternalRequestAsync(method, route, model, cancellationToken).ConfigureAwait(false);

        return JsonSerializer.Deserialize<TModel>(stream, serializerOptions)!;
    }
    
    public async ValueTask<TModel[]> RequestArrayAsync<TModel>(HttpMethod method, string route, ApiModel? model = null, 
        CancellationToken cancellationToken = default) where TModel : ApiModel
    {
        model?.Validate();

        await using var stream = await InternalRequestAsync(method, route, model, cancellationToken).ConfigureAwait(false);
        using var streamReader = new StreamReader(stream);

        return JsonSerializer.Deserialize<TModel[]>(stream, serializerOptions)!;
    }

    private async ValueTask<MemoryStream> InternalRequestAsync(HttpMethod method, string route, ApiModel? model, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using var request = new HttpRequestMessage(method, route);

        if (model is not null)
        {
            var json = JsonSerializer.Serialize(model, serializerOptions);
            request.Content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json", "utf8"));
        }
        
        request.Headers.Add(Token.HeaderName, Token.RawToken);
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Rivoltante", "1.0.0"));

        if (model is IHeaderMetadata { Headers: var headers })
        {
            foreach (var (name, value) in headers)
            {
                request.Headers.Add(name, value);
            }
        }
        
        using var response = await RateLimitHandler.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

        var statusCode = (int) response.StatusCode;
        await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        if (statusCode is > 199 and < 300)
        {
            var memoryStream = new MemoryStream();
            await responseStream.CopyToAsync(memoryStream, cancellationToken);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        if (statusCode is > 499 and < 600)
            throw new HttpRequestException(response.ReasonPhrase, null, response.StatusCode);

        RequestErrorApiModel error;
        try
        {
            error = JsonSerializer.Deserialize<RequestErrorApiModel>(responseStream, serializerOptions)!;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to deserialize the error model.");
            throw new HttpRequestException("Unknown API error.", ex, response.StatusCode);
        }
        finally
        {
            await responseStream.DisposeAsync().ConfigureAwait(false);
        }

        throw new HttpRequestException(error.GetErrorString(), null, response.StatusCode);
    }

    public static string BaseApiUrl { get; set; } = "https://api.revolt.chat/";
}