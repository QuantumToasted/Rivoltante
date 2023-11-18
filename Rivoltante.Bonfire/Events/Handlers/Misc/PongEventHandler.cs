using Microsoft.Extensions.Logging;

namespace Rivoltante.Bonfire;

public sealed class PongEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<PongEventApiModel, PongEventArgs>(eventManager)
{
    public override ValueTask<PongEventArgs?> HandleAsync(IBonfireClient client, PongEventApiModel model)
    {
        if (client.ApiClient is RevoltBonfireApiClient apiClient)
        {
            var now = DateTimeOffset.UtcNow;
            apiClient.Latency = now - apiClient.LastPing;
            Logger.LogInformation("Ping acknowledged - latency is now {Latency}ms.", apiClient.Latency.Value.TotalMilliseconds);
        }
        
        var e = new PongEventArgs(model.Data);
        return new(e);
    }
}