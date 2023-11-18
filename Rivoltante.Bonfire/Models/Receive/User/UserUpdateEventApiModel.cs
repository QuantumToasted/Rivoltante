using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserUpdateEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }
    
    public required PartialUserUpdateApiModel Data { get; init; }

    public required RemovedUserField[] Clear { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.UserUpdate;
}