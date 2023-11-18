namespace Rivoltante.Core;

public interface IServer : IUlidEntity, INamedEntity
{
    Ulid OwnerId { get; }
    
    string? Description { get; }
    
    IReadOnlyList<Ulid> ChannelIds { get; }
    
    IReadOnlyList<IServerChannelCategory> Categories { get; }
    
    IReadOnlyDictionary<SystemMessageType, Ulid> SystemMessageChannelIds { get; }
    
    IReadOnlyDictionary<Ulid, IServerRole> Roles { get; }
    
    Permission DefaultPermissions { get; }
    
    IAttachment? Icon { get; }
    
    IAttachment? Banner { get; }
    
    ServerFlag? Flags { get; }
    
    bool IsNsfw { get; }
    
    bool HasAnalyticsEnabled { get; }
    
    bool IsDiscoverable { get; }
}