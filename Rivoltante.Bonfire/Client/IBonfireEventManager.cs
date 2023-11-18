using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public partial interface IBonfireEventManager : ILogs
{
    IBonfireClient Client { get; }
    
    void Initialize(IBonfireClient client);

    ValueTask HandleDispatchAsync(object? sender, BonfireReceivedEventArgs e);
}