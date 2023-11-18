using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserRelationshipUpdatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<UserRelationshipEventApiModel, UserRelationshipUpdatedEventArgs>(eventManager)
{
    public override ValueTask<UserRelationshipUpdatedEventArgs?> HandleAsync(IBonfireClient client, UserRelationshipEventApiModel model)
    {
        var e = new UserRelationshipUpdatedEventArgs(new CommonUser(model.User, client), model.Status);
        return new(e);
    }
}