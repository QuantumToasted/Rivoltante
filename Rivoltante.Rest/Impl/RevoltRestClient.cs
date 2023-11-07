using Microsoft.Extensions.Logging;

namespace Rivoltante.Rest;

public class RevoltRestClient : IRevoltRestClient
{
    public RevoltRestClient(IRevoltRestApiClient apiClient, ILogger<RevoltRestClient> logger)
    {
        ApiClient = apiClient;
        Logger = logger;
    }

    public IRevoltRestApiClient ApiClient { get; }
    
    public ILogger Logger { get; }
}