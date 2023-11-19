using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rivoltante.Bonfire;
using Rivoltante.Delta;

namespace Rivoltante.Test;

public sealed class TestService(ILogger<TestService> logger, IBonfireEventManager eventManager, IBonfireClient bonfireClient, IDeltaClient deltaApiClient)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        bonfireClient.MessageCreated += MessageCreated;
        bonfireClient.RoleUpdated += RoleUpdated;
        
        logger.LogInformation("Hello, world!");
        eventManager.Initialize(bonfireClient);

        try
        {
            var model = await deltaApiClient.RequestAsync<NodeQueryApiModel>(HttpMethod.Get, RevoltDeltaClient.BaseApiUrl,
                cancellationToken: stoppingToken);
            
            await bonfireClient.RunAsync(new Uri(model.Ws), stoppingToken);
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, "Failed");
        }
    }

    private ValueTask RoleUpdated(object? sender, ServerRoleUpdatedEventArgs e)
    {
        logger.LogInformation("Role {Role} in server {Server} updated", e.RoleId, e.ServerId);
        return ValueTask.CompletedTask;
    }

    private ValueTask MessageCreated(object? sender, MessageCreatedEventArgs e)
    {
        logger.LogInformation("{User} said: {Content}", e.AuthorId, e.Message.Content);
        return ValueTask.CompletedTask;
    }
}