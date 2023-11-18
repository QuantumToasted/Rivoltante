using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelGroupLeftEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ChannelGroupLeaveEventApiModel, ChannelGroupLeftEventArgs>(eventManager)
{
    public override ValueTask<ChannelGroupLeftEventArgs?> HandleAsync(IBonfireClient client, ChannelGroupLeaveEventApiModel model)
    {
        var e = new ChannelGroupLeftEventArgs(model.Id, model.User);
        return new(e);
    }
}