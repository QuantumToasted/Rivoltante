namespace Rivoltante.Bonfire;

public sealed class ChannelGroupJoinedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ChannelGroupJoinEventApiModel, ChannelGroupJoinedEventArgs>(eventManager)
{
    public override ValueTask<ChannelGroupJoinedEventArgs?> HandleAsync(IBonfireClient client, ChannelGroupJoinEventApiModel model)
    {
        var e = new ChannelGroupJoinedEventArgs(model.Id, model.User);
        return new(e);
    }
}