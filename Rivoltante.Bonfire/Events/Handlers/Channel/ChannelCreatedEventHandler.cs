using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelCreatedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ChannelCreateEventApiModel, ChannelCreatedEventArgs>(eventManager)
{
    public override ValueTask<ChannelCreatedEventArgs?> HandleAsync(IBonfireClient client, ChannelCreateEventApiModel model)
    {
        var e = new ChannelCreatedEventArgs(CommonChannel.Create(model, client));
        return new(e);
    }
}