using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerMemberJoinedEventHandler(RevoltBonfireEventManager eventManager) 
    : BonfireEventHandler<ServerMemberJoinEventApiModel, ServerMemberJoinedEventArgs>(eventManager)
{
    public override ValueTask<ServerMemberJoinedEventArgs?> HandleAsync(IBonfireClient client, ServerMemberJoinEventApiModel model)
    {
        var e = new ServerMemberJoinedEventArgs(model.Id, model.User);
        return new(e);
    }
}