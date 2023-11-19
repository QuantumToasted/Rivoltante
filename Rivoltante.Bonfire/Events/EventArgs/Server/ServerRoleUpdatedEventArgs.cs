using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerRoleUpdatedEventArgs(Ulid serverId, Ulid roleId, PartialServerRoleUpdateApiModel model, IEnumerable<RemovedRoleField> removedFields) 
    : EventArgs
{
    public Ulid ServerId { get; } = serverId;
    
    public Ulid RoleId { get; } = roleId;
    
    public PartialServerRoleUpdateApiModel Model { get; } = model;
    
    public IReadOnlyList<RemovedRoleField> RemovedFields { get; } = removedFields.ToList();
}