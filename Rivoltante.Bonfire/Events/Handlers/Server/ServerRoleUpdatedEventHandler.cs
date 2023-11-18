using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class ServerRoleUpdatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ServerRoleUpdateEventApiModel, ServerRoleUpdatedEventArgs>(eventManager)
{
    public override ValueTask<ServerRoleUpdatedEventArgs?> HandleAsync(IBonfireClient client, ServerRoleUpdateEventApiModel model)
    {
        var e = new ServerRoleUpdatedEventArgs(model.Id, model.RoleId, model.Data, model.Clear);
        return new(e);
    }
}