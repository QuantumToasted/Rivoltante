using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessagesAcknowledgedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ChannelAckEventApiModel, MessagesAcknowledgedEventArgs>(eventManager)
{
    public override ValueTask<MessagesAcknowledgedEventArgs?> HandleAsync(IBonfireClient client, ChannelAckEventApiModel model)
    {
        var e = new MessagesAcknowledgedEventArgs(model.Id, model.User, model.Id);
        return new(e);
    }
}