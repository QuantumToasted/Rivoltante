using Rivoltante.Core;

namespace Rivoltante.Delta;

public interface IDeltaClient : IRevoltClient
{
    new IDeltaApiClient ApiClient { get; }
    
    IRevoltApiClient IRevoltClient.ApiClient => ApiClient;
}