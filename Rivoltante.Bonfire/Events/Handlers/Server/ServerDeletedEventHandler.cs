using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerDeletedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ServerDeleteEventApiModel, ServerDeletedEventArgs>(eventManager)
{
    public override ValueTask<ServerDeletedEventArgs?> HandleAsync(IBonfireClient client, ServerDeleteEventApiModel model)
    {
        var e = new ServerDeletedEventArgs(model.Id);
        return new(e);
    }
}