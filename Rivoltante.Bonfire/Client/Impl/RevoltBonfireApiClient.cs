using System.Buffers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class RevoltBonfireApiClient : IBonfireApiClient
{
    private const int BUFFER_SIZE = 8192;
    
    private static readonly TimeSpan BaseReconnectDelay = TimeSpan.FromSeconds(5);
    
    private readonly ClientWebSocket _ws;

    public RevoltBonfireApiClient(ILogger<RevoltBonfireApiClient> logger, Token token, JsonSerializerOptions serializerOptions)
    {
        _ws = new ClientWebSocket();
        _ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(10); // between 10-30 seconds

        Logger = logger;
        Token = token;
        SerializerOptions = serializerOptions;
    }
    
    internal DateTimeOffset LastPing { get; set; }

    public ILogger Logger { get; }
    
    public Token Token { get; }
    
    public JsonSerializerOptions SerializerOptions { get; }

    public AsyncEvent<BonfireReceivedEventArgs> ReceivedEvent { get; } = new();
    
    public TimeSpan? Latency { get; internal set; }
    
    public async ValueTask RunAsync(Uri uri, CancellationToken cancellationToken)
    {
        var reconnectAttempts = 0;
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await _ws.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
                
                reconnectAttempts = 0; // reset to 0 on successful connection
                Logger.LogInformation("Connected to {Uri} via ClientWebSocket.", uri);

                var authBytes = JsonSerializer.SerializeToUtf8Bytes(new AuthenticateEventApiModel { Token = Token.RawToken }, SerializerOptions);
                await _ws.SendAsync(authBytes, WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
                
                _ = LoopReceiveAsync(cancellationToken).AsTask();
                _ = LoopPingAsync(cancellationToken).AsTask();

                await Task.Delay(-1, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                reconnectAttempts = Math.Min(++reconnectAttempts, 6);
                var delay = BaseReconnectDelay * reconnectAttempts;
                Logger.LogError(ex, "An exception occured attempting to connect to {Uri} via ClientWebSocket. Trying again in {Delay}.", uri, delay);

                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private async ValueTask LoopReceiveAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var buffer = ArrayPool<byte>.Shared.Rent(BUFFER_SIZE);

            try
            {
                var result = await _ws.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
                var jsonStream = new MemoryStream();
                await jsonStream.WriteAsync(buffer.AsMemory(0, result.Count), cancellationToken);
                jsonStream.Seek(0, SeekOrigin.Begin);

                var model = JsonSerializer.Deserialize<IReceiveEventApiModel>(jsonStream, SerializerOptions);
                
                Ensure.NotNull(model);
                
                await ReceivedEvent.InvokeAsync(this, new BonfireReceivedEventArgs(model));
            }
            catch (InvalidOperationException ex) // ws not connected
            {
                Logger.LogWarning(ex, "The ClientWebSocket is not connected (state {State}, message {Message}).", _ws.State, _ws.CloseStatusDescription);
                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "An exception occurred attempting to receive data from Bonfire via ClientWebSocket.");
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer, true);
            }
        }
    }

    private async ValueTask LoopPingAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(30), cancellationToken).ConfigureAwait(false);
                var now = DateTimeOffset.UtcNow;
                var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(new PingEventApiModel { Data = now.ToUnixTimeSeconds() }, SerializerOptions);
                LastPing = now;
                await _ws.SendAsync(jsonBytes, WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred attempting to ping the Bonfire server via ClientWebSocket.");
            }
        }
    }
}