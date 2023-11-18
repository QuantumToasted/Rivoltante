namespace Rivoltante.Core;

public interface IServerChannel : IChannel, IServerEntity, INamedEntity
{
    string? Description { get; }
    
    IAttachment? Icon { get; }
    
    IPermissions? DefaultPermissions { get; }
    
    IReadOnlyDictionary<Ulid, IPermissions> RolePermissions { get; }
    
    bool IsNsfw { get; }
}