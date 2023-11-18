using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserRelationshipEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }
    
    public required UserApiModel User { get; init; }
    
    public required UserRelationshipStatus Status { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.UserRelationship;
}