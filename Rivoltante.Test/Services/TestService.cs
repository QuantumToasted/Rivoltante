using Microsoft.Extensions.Logging;
using Rivoltante.Bonfire;
using Rivoltante.Delta;

namespace Rivoltante.Test;

public sealed class TestService(ILogger<TestService> logger, IBonfireEventManager eventManager, IBonfireClient bonfireClient, IDeltaApiClient deltaApiClient)
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Hello, world!");
        eventManager.Initialize(bonfireClient);

        try
        {
            var model = await deltaApiClient.RequestAsync<NodeQueryApiModel>(HttpMethod.Get, RevoltDeltaApiClient.BaseApiUrl,
                cancellationToken: cancellationToken);
            
            await bonfireClient.RunAsync(new Uri(model.Ws), cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, "Failed");
        }
    }
}