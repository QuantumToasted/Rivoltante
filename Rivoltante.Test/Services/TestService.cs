using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rivoltante.Core;
using Rivoltante.Rest;

namespace Rivoltante.Test.Services;

public class TestService(IRevoltRestClient restClient, ILogger<TestService> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _ = Task.Run(async () =>
        {
            try
            {
                var channel = await restClient.CreateTextChannelAsync("01H2SK15KZ914SN7MXDA5SFE4A", "test channel",
                    cancellationToken: cancellationToken);

                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);

                await restClient.ModifyServerChannelAsync(channel.Id, x => x.Name = "cooler test channel", cancellationToken);

                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);

                await restClient.CloseChannelAsync(channel.Id, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to create and modify a text channel.");
            }
        }, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}