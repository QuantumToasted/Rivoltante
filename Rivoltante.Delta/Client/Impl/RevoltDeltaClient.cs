using Microsoft.Extensions.Logging;

namespace Rivoltante.Delta;

public class RevoltDeltaClient(ILogger<RevoltDeltaClient> logger, IDeltaApiClient apiClient) : IDeltaClient
{
    public ILogger Logger { get; } = logger;

    public IDeltaApiClient ApiClient { get; } = apiClient;
}