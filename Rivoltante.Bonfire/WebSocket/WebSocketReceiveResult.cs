using System.Net.WebSockets;

namespace Rivoltante.Bonfire;

public readonly record struct WebSocketReceiveResult(int Size, WebSocketMessageType MessageType, bool IsEndOfMessage);