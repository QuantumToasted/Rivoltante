using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rivoltante.Rest;

namespace Rivoltante.Test.Services;

public class TestService(IRevoltRestClient restClient, ILogger<TestService> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var messages = await restClient.FetchMessagesAsync("01H2SK15KZ05FZXV9XQ3QN1QBA", includeUsers: true, cancellationToken: cancellationToken);
            logger.LogInformation("Count: {Count}", messages.Messages.Count);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}