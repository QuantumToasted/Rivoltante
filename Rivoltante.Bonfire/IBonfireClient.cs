using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireClient : IRevoltClient
{
    new IBonfireApiClient ApiClient { get; }
    
    IBonfireEventManager EventManager { get; }
    
    IBonfireCacheProvider CacheProvider { get; }

    Task RunAsync(Uri uri, CancellationToken cancellationToken);

    IRevoltApiClient IRevoltClient.ApiClient => ApiClient;
}