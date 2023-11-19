using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelTypingStartedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ChannelStartTypingEventApiModel, ChannelTypingStartedEventArgs>(eventManager)
{
    public override ValueTask<ChannelTypingStartedEventArgs?> HandleAsync(IBonfireClient client, ChannelStartTypingEventApiModel model)
    {
        var e = new ChannelTypingStartedEventArgs(model.Id, model.User);
        return new(e);
    }
}