using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class ServerUpdatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ServerUpdateEventApiModel, ServerUpdatedEventArgs>(eventManager)
{
    public override ValueTask<ServerUpdatedEventArgs?> HandleAsync(IBonfireClient client, ServerUpdateEventApiModel model)
    {
        var e = new ServerUpdatedEventArgs(model.Id, model.Data, model.Clear);
        return new(e);
    }
}