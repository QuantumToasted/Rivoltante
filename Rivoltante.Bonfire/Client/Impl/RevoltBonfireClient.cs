using Microsoft.Extensions.Logging;

namespace Rivoltante.Bonfire;

public sealed partial class RevoltBonfireClient(ILogger<RevoltBonfireClient> logger, IBonfireEventManager eventManager, IBonfireApiClient apiClient)
    : IBonfireClient
{
    public ILogger Logger { get; } = logger;

    public IBonfireEventManager EventManager { get; } = eventManager;

    public IBonfireApiClient ApiClient { get; } = apiClient;

    public ValueTask RunAsync(Uri uri, CancellationToken cancellationToken)
        => ApiClient.RunAsync(uri, cancellationToken);
}