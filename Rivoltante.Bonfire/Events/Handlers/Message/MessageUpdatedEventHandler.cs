using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageUpdatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<MessageUpdateEventApiModel, MessageUpdatedEventArgs>(eventManager)
{
    public override ValueTask<MessageUpdatedEventArgs?> HandleAsync(IBonfireClient client, MessageUpdateEventApiModel model)
    {
        var e = new MessageUpdatedEventArgs(model.Id, model.Channel, model.Data);
        return new(e);
    }
}