using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelUpdatedEventHandler(RevoltBonfireEventManager eventManager)
    : BonfireEventHandler<ChannelUpdateEventApiModel, ChannelUpdatedEventArgs>(eventManager)
{
    public override ValueTask<ChannelUpdatedEventArgs?> HandleAsync(IBonfireClient client, ChannelUpdateEventApiModel model)
    {
        var e = new ChannelUpdatedEventArgs(model);
        return new(e);
    }
}