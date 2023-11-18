using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireApiClient : IRevoltApiClient
{
    TimeSpan? Latency { get; }
    
    AsyncEvent<BonfireReceivedEventArgs> ReceivedEvent { get; }
    
    ValueTask RunAsync(Uri uri, CancellationToken cancellationToken);
}