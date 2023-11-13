using System.Net.WebSockets;
using Microsoft.Extensions.Logging;

namespace Rivoltante.Bonfire;

public sealed class RevoltWebSocket(ILogger<RevoltWebSocket> logger, IWebSocketClientFactory clientFactory)
    : IAsyncDisposable
{
    private const int BUFFER_SIZE = 8192;
    
    private readonly SemaphoreSlim _receiveSemaphore = new(1, 1);
    private readonly SemaphoreSlim _sendSemaphore = new(1, 1);
        
    private IWebSocketClient? _ws;

    public ILogger Logger { get; } = logger;

    public async ValueTask ConnectAsync(Uri uri, CancellationToken cancellationToken)
    {
        await _receiveSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        await _sendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            _ws?.Dispose();
            _ws = clientFactory.CreateClient();

            await _ws.ConnectAsync(uri, cancellationToken);
            Logger.LogInformation("Connected to websocket via {Uri}, state {State}.", uri, _ws.CurrentState);
        }
        finally
        {
            _receiveSemaphore.Release();
            _sendSemaphore.Release();
        }
    }

    public async ValueTask<Stream> ReceiveAsync(CancellationToken cancellationToken)
    {
        await _receiveSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        
        var stream = new MemoryStream();
        
        try
        {
            var buffer = new byte[BUFFER_SIZE];
            var result = await _ws!.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
            
            await stream.WriteAsync(buffer.AsMemory(0, result.Size), cancellationToken);
            
            Logger.LogInformation("Received {Count} byte(s) via WS, state {State}.", result.Size, _ws.CurrentState);

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
        finally
        {
            _receiveSemaphore.Release();
        }
    }

    public async ValueTask SendAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken)
    {
        await _sendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            await _ws!.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
            Logger.LogInformation("Sent {Count} byte(s) via WS, state {State}.", buffer.Length, _ws.CurrentState);
        }
        finally
        {
            _sendSemaphore.Release();
        }
    }
    
    public async ValueTask CloseAsync(int closeCode, string? closeMessage, CancellationToken cancellationToken = default)
    {
        await _receiveSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        await _sendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

        if (_ws?.CurrentState is not WebSocketState.Aborted)
        {
            try
            {
                await _ws!.CloseAsync(closeCode, closeMessage, cancellationToken).ConfigureAwait(false);
            }
            catch { /* ignored */ }
            
            Logger.LogInformation("Closed WS connection with code {Code}, message [{Message}].", closeCode, closeMessage);
        }
        
        _receiveSemaphore.Release();
        _sendSemaphore.Release();
    }

    public async ValueTask DisposeAsync()
    {
        await _receiveSemaphore.WaitAsync().ConfigureAwait(false);
        await _sendSemaphore.WaitAsync().ConfigureAwait(false);
        
        _ws?.Dispose();
        
        _receiveSemaphore.Release();
        _sendSemaphore.Release();
    }
}