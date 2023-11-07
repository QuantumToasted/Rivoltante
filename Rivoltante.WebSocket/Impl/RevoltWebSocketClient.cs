using Microsoft.Extensions.Logging;

namespace Rivoltante.WebSocket;

public class RevoltWebSocketClient : IRevoltWebSocketClient
{
    public IRevoltWebSocketApiClient ApiClient { get; }
    
    public ILogger Logger { get; }
}