using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserUpdatedEventArgs(Ulid userId, PartialUserUpdateApiModel model, IEnumerable<RemovedUserField> removedFields) : EventArgs
{
    public Ulid UserId { get; } = userId;
    
    public PartialUserUpdateApiModel Model { get; } = model;
    
    public IReadOnlyList<RemovedUserField> RemovedFields { get; } = removedFields.ToList();
}