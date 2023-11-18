using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageCreatedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<MessageEventApiModel, MessageCreatedEventArgs>(eventManager)
{
    public override ValueTask<MessageCreatedEventArgs?> HandleAsync(IBonfireClient client, MessageEventApiModel model)
    {
        var e = new MessageCreatedEventArgs(new CommonMessage(model, client));
        return new(e);
    }
}