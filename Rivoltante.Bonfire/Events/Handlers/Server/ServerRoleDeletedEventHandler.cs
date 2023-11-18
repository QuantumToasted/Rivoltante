using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerRoleDeletedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ServerRoleDeleteEventApiModel, ServerRoleDeletedEventArgs>(eventManager)
{
    public override ValueTask<ServerRoleDeletedEventArgs?> HandleAsync(IBonfireClient client, ServerRoleDeleteEventApiModel model)
    {
        var e = new ServerRoleDeletedEventArgs(model.Id, model.RoleId);
        return new(e);
    }
}