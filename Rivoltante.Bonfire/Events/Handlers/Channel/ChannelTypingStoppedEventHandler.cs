using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelTypingStoppedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ChannelStopTypingEventApiModel, ChannelTypingStoppedEventArgs>(eventManager)
{
    public override ValueTask<ChannelTypingStoppedEventArgs?> HandleAsync(IBonfireClient client, ChannelStopTypingEventApiModel model)
    {
        var e = new ChannelTypingStoppedEventArgs(model.Id, model.User);
        return new(e);
    }
}