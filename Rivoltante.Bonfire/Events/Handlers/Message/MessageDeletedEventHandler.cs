using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageDeletedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<MessageDeleteEventApiModel, MessageDeletedEventArgs>(eventManager)
{
    public override ValueTask<MessageDeletedEventArgs?> HandleAsync(IBonfireClient client, MessageDeleteEventApiModel model)
    {
        var e = new MessageDeletedEventArgs(model.Id, model.Channel);
        return new(e);
    }
}