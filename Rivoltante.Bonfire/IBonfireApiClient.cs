using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireApiClient : IRevoltApiClient
{
    IBonfireConnection Bonfire { get; }
    
    IBonfireHeartbeater Heartbeater { get; }
    
    AsyncEvent<IncomingEventReceivedEventArgs> IncomingEvent { get; }

    ValueTask RunAsync(Uri uri, CancellationToken cancellationToken);
}