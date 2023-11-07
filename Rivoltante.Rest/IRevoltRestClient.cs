using Rivoltante.Core;

namespace Rivoltante.Rest;

public interface IRevoltRestClient : IRevoltClient
{
    new IRevoltRestApiClient ApiClient { get; }
    IRevoltApiClient IRevoltClient.ApiClient => ApiClient;
}