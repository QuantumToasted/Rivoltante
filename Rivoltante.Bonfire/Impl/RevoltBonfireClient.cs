using Microsoft.Extensions.Logging;

namespace Rivoltante.Bonfire;

public class RevoltBonfireClient(ILogger<RevoltBonfireClient> logger, IBonfireApiClient apiClient, IBonfireEventManager eventManager)
    : IBonfireClient
{
    public IBonfireApiClient ApiClient { get; } = apiClient;

    public IBonfireEventManager EventManager { get; } = eventManager;

    public ILogger Logger { get; } = logger;

    public Task RunAsync(Uri uri, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}