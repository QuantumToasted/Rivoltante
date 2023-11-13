using System.Net.WebSockets;

namespace Rivoltante.Bonfire;

public interface IWebSocketClient : IDisposable
{
    WebSocketState CurrentState { get; }
    
    int? CloseCode { get; }
    
    string? CloseMessage { get; }

    ValueTask ConnectAsync(Uri uri, CancellationToken cancellationToken = default);

    ValueTask CloseAsync(int closeCode, string? closeMessage, CancellationToken cancellationToken = default);

    ValueTask CloseOutputAsync(int closeCode, string? closeMessage, CancellationToken cancellationToken = default);

    ValueTask<WebSocketReceiveResult> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);

    ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool isEndOfMessage, CancellationToken cancellationToken = default);
}