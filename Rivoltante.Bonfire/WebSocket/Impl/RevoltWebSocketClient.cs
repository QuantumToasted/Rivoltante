using System.Net.WebSockets;

namespace Rivoltante.Bonfire;

public sealed class RevoltWebSocketClient(ClientWebSocket ws) : IWebSocketClient
{
    public WebSocketState CurrentState => ws.State;
    
    public int? CloseCode => ws.CloseStatus.HasValue ? (int)ws.CloseStatus : null;

    public string? CloseMessage => ws.CloseStatusDescription;

    public async ValueTask ConnectAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        try
        {
            await ws.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebSocketClosedException(CloseCode, CloseMessage, ex);
        }
    }

    public async ValueTask CloseAsync(int closeCode, string? closeMessage, CancellationToken cancellationToken = default)
    {
        try
        {
            await ws.CloseAsync((WebSocketCloseStatus) closeCode, closeMessage, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebSocketClosedException(CloseCode, CloseMessage, ex);
        }
    }

    public async ValueTask CloseOutputAsync(int closeCode, string? closeMessage, CancellationToken cancellationToken = default)
    {
        try
        {
            await ws.CloseOutputAsync((WebSocketCloseStatus)closeCode, closeMessage, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebSocketClosedException(CloseCode, CloseMessage, ex);
        }
    }

    public async ValueTask<WebSocketReceiveResult> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await ws.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
            return new WebSocketReceiveResult(result.Count, result.MessageType, result.EndOfMessage);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebSocketClosedException(CloseCode, CloseMessage, ex);
        }
    }

    public async ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool isEndOfMessage, CancellationToken cancellationToken = default)
    {
        try
        {
            await ws.SendAsync(buffer, messageType, isEndOfMessage, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebSocketClosedException(CloseCode, CloseMessage, ex);
        }
    }

    public void Dispose()
        => ws.Dispose();
}