namespace Rivoltante.Core;

public interface IServerChannel : IChannel, IServerEntity
{
    string Name { get; }
    
    string? Description { get; }
    
    IAttachment? Icon { get; }
    
    IPermissionOverride? DefaultPermissions { get; }
    
    IReadOnlyDictionary<Ulid, IPermissionOverride> RolePermissions { get; }
    
    bool IsNsfw { get; }
}