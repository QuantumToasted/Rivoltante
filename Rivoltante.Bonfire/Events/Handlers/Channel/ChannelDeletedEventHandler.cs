namespace Rivoltante.Bonfire;

public sealed class ChannelDeletedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ChannelDeleteEventApiModel, ChannelDeletedEventArgs>(eventManager)
{
    public override ValueTask<ChannelDeletedEventArgs?> HandleAsync(IBonfireClient client, ChannelDeleteEventApiModel model)
    {
        var e = new ChannelDeletedEventArgs(model.Id);
        return new(e);
    }
}