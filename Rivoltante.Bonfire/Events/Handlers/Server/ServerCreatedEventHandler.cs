using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerCreatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ServerCreateEventApiModel, ServerCreatedEventArgs>(eventManager)
{
    public override ValueTask<ServerCreatedEventArgs?> HandleAsync(IBonfireClient client, ServerCreateEventApiModel model)
    {
        var e = new ServerCreatedEventArgs(new CommonServer(model, client));
        return new(e);
    }
}