using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerMemberUpdatedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ServerMemberUpdateEventApiModel, ServerMemberUpdatedEventArgs>(eventManager)
{
    public override ValueTask<ServerMemberUpdatedEventArgs?> HandleAsync(IBonfireClient client, ServerMemberUpdateEventApiModel model)
    {
        var e = new ServerMemberUpdatedEventArgs(model.Id.Server, model.Id.User, model.Data, model.Clear);
        return new(e);
    }
}