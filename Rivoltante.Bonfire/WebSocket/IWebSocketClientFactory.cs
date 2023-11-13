namespace Rivoltante.Bonfire;

public interface IWebSocketClientFactory
{
    IWebSocketClient CreateClient();
}