using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserRelationshipUpdatedEventArgs(IUser user, UserRelationshipStatus newStatus) : EventArgs
{
    public IUser User { get; } = user;
    
    public UserRelationshipStatus NewStatus { get; } = newStatus;

    public Ulid UserId => User.Id;
}