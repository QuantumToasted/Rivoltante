using Rivoltante.Core;

namespace Rivoltante.Bonfire.Message;

public class MessageEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<MessageEventApiModel, MessageEventArgs>(eventManager)
{
    protected override ValueTask<MessageEventArgs?> HandleEventAsync(IRevoltClient client, MessageEventApiModel model)
    {
        return ValueTask.FromResult<MessageEventArgs?>(new MessageEventArgs(new BonfireMessage(client, model)));
    }
}