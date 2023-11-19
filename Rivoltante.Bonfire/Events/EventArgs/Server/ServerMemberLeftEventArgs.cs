using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerMemberLeftEventArgs(Ulid serverId, Ulid memberId) : EventArgs
{
    public Ulid ServerId { get; } = serverId;
    
    public Ulid MemberId { get; } = memberId;
}