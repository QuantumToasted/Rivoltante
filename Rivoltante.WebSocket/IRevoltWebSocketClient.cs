using Rivoltante.Core;

namespace Rivoltante.WebSocket;

public interface IRevoltWebSocketClient : IRevoltClient
{
    new IRevoltWebSocketApiClient ApiClient { get; }

    IRevoltApiClient IRevoltClient.ApiClient => ApiClient;
}