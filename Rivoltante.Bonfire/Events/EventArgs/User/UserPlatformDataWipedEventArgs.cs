using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserPlatformDataWipedEventArgs(Ulid userId, UserFlag flags) : EventArgs
{
    public Ulid UserId { get; } = userId;
    
    public UserFlag Flags { get; } = flags;
}