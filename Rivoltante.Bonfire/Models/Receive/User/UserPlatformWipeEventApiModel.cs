using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserPlatformWipeEventApiModel : IReceiveEventApiModel
{
    public required Ulid UserId { get; init; }

    public required string Flags { get; init; }
    
    public ReceiveEventType? Type => ReceiveEventType.UserPlatformWipe;
}