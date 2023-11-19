using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerMemberLeftEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ServerMemberLeaveApiModel, ServerMemberLeftEventArgs>(eventManager)
{
    public override ValueTask<ServerMemberLeftEventArgs?> HandleAsync(IBonfireClient client, ServerMemberLeaveApiModel model)
    {
        var e = new ServerMemberLeftEventArgs(model.Id, model.User);
        return new(e);
    }
}