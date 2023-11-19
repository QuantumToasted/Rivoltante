using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class RevoltDeltaClient(ILogger<RevoltDeltaClient> logger, Token token, IDeltaRateLimiter rateLimiter, JsonSerializerOptions serializerOptions) : IDeltaClient
{
    public ILogger Logger { get; } = logger;
    
    public Token Token { get; } = token;

    public IDeltaRateLimiter RateLimiter { get; } = rateLimiter;

    public JsonSerializerOptions SerializerOptions { get; } = serializerOptions;
    
    public static string BaseApiUrl { get; set; } = "https://api.revolt.chat/";

    public async ValueTask RequestAsync(HttpMethod method, string route, IApiModel? model = null, CancellationToken cancellationToken = default)
    {
        await using var stream = await InternalRequestAsync(method, route, model, cancellationToken).ConfigureAwait(false);
    }

    public async ValueTask<TModel> RequestAsync<TModel>(HttpMethod method, string route, IApiModel? model = null, CancellationToken cancellationToken = default) 
        where TModel : IApiModel
    {
        await using var stream = await InternalRequestAsync(method, route, model, cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<TModel>(stream, SerializerOptions)!;
    }

    private async ValueTask<MemoryStream> InternalRequestAsync(HttpMethod method, string route, IApiModel? model, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using var request = new HttpRequestMessage(method, route);

        if (model is not null)
        {
            model.Validate();
            
            var json = JsonSerializer.Serialize(model, SerializerOptions);
            request.Content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json", "utf8"));
        }
        
        request.Headers.Add(Token.HeaderName, Token.RawToken);
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Rivoltante", "0.0.1"));

        if (model is IHeaderMetadata { Headers: var headers })
        {
            foreach (var (name, value) in headers)
            {
                request.Headers.Add(name, value);
            }
        }

        using var response = await RateLimiter.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

        var statusCode = (int)response.StatusCode;
        await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        switch (statusCode)
        {
            case > 199 and < 300: // 2XX
            {
                var memoryStream = new MemoryStream();
                await responseStream.CopyToAsync(memoryStream, cancellationToken);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return memoryStream;
            }
            case > 499 and < 600: // 5XX
            {
                throw new DeltaApiException(response.StatusCode, response.ReasonPhrase);
            }
            default: // 3XX, 4XX, 1XX, etc
            {
                ErrorResponseApiModel errorModel;
                try
                {
                    errorModel = JsonSerializer.Deserialize<ErrorResponseApiModel>(responseStream, SerializerOptions)!;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Failed to deserialize the error model.");
                    throw new DeltaApiException(response.StatusCode, "Unknown API error.");
                }
                finally
                {
                    await responseStream.DisposeAsync().ConfigureAwait(false);
                }

                throw new DeltaApiException(response.StatusCode, errorModel);
            }
        }
    }
}