using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rivoltante.Bonfire;
using Rivoltante.Core;
using Rivoltante.Rest;

namespace Rivoltante.Test;

public class TestService(IRevoltRestClient restClient, ILogger<TestService> logger, IBonfireConnection bonfire, Token token) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var node = await restClient.ApiClient.QueryNodeAsync(cancellationToken);
            await bonfire.ConnectAsync(new Uri(node.Ws), cancellationToken);

            var model = new AuthenticateEventApiModel(token.RawToken);

            await bonfire.SendAsync(model, cancellationToken);

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed");
        }
        /*
        try
        {
            var messages = await restClient.FetchMessagesAsync("01H2SK15KZ05FZXV9XQ3QN1QBA", includeUsers: true, cancellationToken: cancellationToken);
            logger.LogInformation("Count: {Count}", messages.Messages.Count);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed");
        }
        */
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}