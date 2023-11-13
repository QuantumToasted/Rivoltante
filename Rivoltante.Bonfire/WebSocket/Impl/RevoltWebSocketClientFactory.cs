
using System.Net.WebSockets;

namespace Rivoltante.Bonfire;

public class RevoltWebSocketClientFactory : IWebSocketClientFactory
{
    public IWebSocketClient CreateClient()
    {
        var ws = new ClientWebSocket();
        ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(10); // between 10-30
        return new RevoltWebSocketClient(ws);
    }
}