using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserUpdatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<UserUpdateEventApiModel, UserUpdatedEventArgs>(eventManager)
{
    public override ValueTask<UserUpdatedEventArgs?> HandleAsync(IBonfireClient client, UserUpdateEventApiModel model)
    {
        var e = new UserUpdatedEventArgs(model.Id, model.Data, model.Clear);
        return new(e);
    }
}