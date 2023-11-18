using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public partial interface IBonfireClient : IRevoltClient
{
    new IBonfireApiClient ApiClient { get; }
    
    IBonfireEventManager EventManager { get; }

    ValueTask RunAsync(Uri uri, CancellationToken cancellationToken);
    
    IRevoltApiClient IRevoltClient.ApiClient => ApiClient;
}