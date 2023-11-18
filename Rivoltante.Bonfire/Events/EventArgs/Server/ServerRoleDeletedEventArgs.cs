using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerRoleDeletedEventArgs(Ulid serverId, Ulid roleId) : EventArgs
{
    public Ulid ServerId { get; } = serverId;
    
    public Ulid RoleId { get; } = roleId;
}