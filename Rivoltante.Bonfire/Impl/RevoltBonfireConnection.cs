using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace Rivoltante.Bonfire;

public class RevoltBonfireConnection(JsonSerializerOptions serializerOptions, ILogger<RevoltBonfireConnection> logger, ILoggerFactory loggerFactory, IWebSocketClientFactory clientFactory)
    : IBonfireConnection
{
    private readonly RevoltWebSocket _ws = new(loggerFactory.CreateLogger<RevoltWebSocket>(), clientFactory);
    
    public IWebSocketClientFactory ClientFactory { get; } = clientFactory;

    public ValueTask ConnectAsync(Uri uri, CancellationToken cancellationToken)
    {
        logger.LogInformation("Connecting to Bonfire host {Host}.", uri);
        return _ws.ConnectAsync(uri, cancellationToken);
    }

    public ValueTask CloseAsync(int closeCode, string? closeMessage, CancellationToken cancellationToken)
    {
        logger.LogInformation("Closing connection to Bonfire host (code \"{Code}: {Message}\")", closeCode, closeMessage);
        return _ws.CloseAsync(closeCode, closeMessage, cancellationToken);
    }
    
    public async ValueTask<TModel> ReceiveAsync<TModel>(CancellationToken cancellationToken) where TModel : IncomingEventApiModel
    {
        var jsonStream = await _ws.ReceiveAsync(cancellationToken).ConfigureAwait(false);
        
        // TODO: remove or lock behind a setting
        {
            var stream = new MemoryStream();
            await jsonStream.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            logger.LogInformation("Received event: {Model}", Encoding.UTF8.GetString(stream.ToArray()));
            //stream.Position = 0;
            //jsonStream = stream;
            jsonStream.Seek(0, SeekOrigin.Begin);
        }

        try
        {
            var model = await JsonSerializer.DeserializeAsync<TModel>(jsonStream, serializerOptions, cancellationToken).ConfigureAwait(false);
            return model!;
        }
        finally
        {
            await jsonStream.DisposeAsync().ConfigureAwait(false);
        }
    }

    public async ValueTask SendAsync<TModel>(TModel model, CancellationToken cancellationToken) where TModel : OutgoingEventApiModel
    {
        using var jsonStream = new MemoryStream();
        await JsonSerializer.SerializeAsync(jsonStream, model, serializerOptions, cancellationToken).ConfigureAwait(false);        
        
        // TODO: remove or lock behind a setting
        logger.LogInformation("Sending event: {Model}", Encoding.UTF8.GetString(jsonStream.ToArray()));

        await _ws.SendAsync(jsonStream.ToArray(), cancellationToken).ConfigureAwait(false);
    }

    public ValueTask DisposeAsync()
        => _ws.DisposeAsync();
}