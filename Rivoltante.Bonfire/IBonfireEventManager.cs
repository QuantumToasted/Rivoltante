namespace Rivoltante.Bonfire;

public partial interface IBonfireEventManager
{
    IBonfireClient Client { get; }

    ValueTask HandleDispatchAsync(object? sender, IncomingEventReceivedEventArgs e);
}