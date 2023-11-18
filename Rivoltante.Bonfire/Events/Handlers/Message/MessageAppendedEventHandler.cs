namespace Rivoltante.Bonfire;

public sealed class MessageAppendedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<MessageAppendEventApiModel, MessageUpdatedEventArgs>(eventManager)
{
    public override ValueTask<MessageUpdatedEventArgs?> HandleAsync(IBonfireClient client, MessageAppendEventApiModel model)
    {
        var e = new MessageUpdatedEventArgs(model.Id, model.Channel, model.Append);
        return new(e);
    }
}