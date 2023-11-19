using System.Buffers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed partial class RevoltBonfireClient : IBonfireClient
{
    private const int BUFFER_SIZE = 8192;
    
    private static readonly TimeSpan BaseReconnectDelay = TimeSpan.FromSeconds(5);
    
    private readonly ClientWebSocket _ws;
    
    public RevoltBonfireClient(ILogger<RevoltBonfireClient> logger, Token token, IBonfireEventManager eventManager, JsonSerializerOptions serializerOptions)
    {
        _ws = new ClientWebSocket();
        _ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(10); // between 10-30 seconds

        Logger = logger;
        Token = token;
        SerializerOptions = serializerOptions;
        EventManager = eventManager;
    }
    
    public ILogger Logger { get; }
    
    public Token Token { get; }
    
    public JsonSerializerOptions SerializerOptions { get; }

    public IBonfireEventManager EventManager { get; }
    
    internal DateTimeOffset LastPing { get; set; }
    
    public AsyncEvent<BonfireReceivedEventArgs> ReceivedEvent { get; } = new();
    
    public TimeSpan? Latency { get; internal set; }
    
    public async ValueTask SendAsync<TModel>(TModel model, CancellationToken cancellationToken) where TModel : class, ISendEventApiModel
    {
        var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(model, SerializerOptions);
        await _ws.SendAsync(jsonBytes, WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
        Logger.LogDebug("Sent event model {Type}.", model.GetType());
        Logger.LogTrace("Data: {Json}", Encoding.UTF8.GetString(jsonBytes));
    }

    public async ValueTask<TModel> ReceiveAsync<TModel>(CancellationToken cancellationToken) where TModel : class, IReceiveEventApiModel
    {
        var jsonBuffer = ArrayPool<byte>.Shared.Rent(BUFFER_SIZE);

        try
        {
            var result = await _ws.ReceiveAsync(jsonBuffer, cancellationToken).ConfigureAwait(false);
            var model = JsonSerializer.Deserialize<TModel>(jsonBuffer.AsSpan(0, result.Count), SerializerOptions);
            Ensure.NotNull(model);
            return model;
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(jsonBuffer, true);
        }
    }

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

                await SendAsync(new AuthenticateEventApiModel { Token = Token.RawToken }, cancellationToken).ConfigureAwait(false);

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
            try
            {
                var model = await ReceiveAsync<IReceiveEventApiModel>(cancellationToken).ConfigureAwait(false);
                await ReceivedEvent.InvokeAsync(this, new BonfireReceivedEventArgs(model)).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                Logger.LogError("The receive loop was canceled due to the cancellation token being canceled.");
                break;
            }
            catch (Exception ex)
            {
                var delay = TimeSpan.FromSeconds(10);
                Logger.LogError(ex, "An exception occurred during the receive loop. Delaying for {Delay}ms.", delay.TotalMilliseconds);
                await Task.Delay(delay, cancellationToken);
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
                await SendAsync(new PingEventApiModel { Data = now.ToUnixTimeSeconds() }, cancellationToken).ConfigureAwait(false);
                LastPing = now;
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