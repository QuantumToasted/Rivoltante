namespace Rivoltante.Core;

public interface IServer : IUlidEntity
{
    Ulid OwnerId { get; }
    
    string Name { get; }
    
    string? Description { get; }
    
    IReadOnlyList<Ulid> ChannelIds { get; }
    
    IReadOnlyList<IServerChannelCategory> Categories { get; }
    
    Ulid? UserJoinedChannelId { get; }
    
    Ulid? UserLeftChannelId { get; }
    
    Ulid? UserKickedChannelId { get; }
    
    Ulid? UserBannedChannelId { get; }
    
    IReadOnlyDictionary<Ulid, IServerRole> Roles { get; }
    
    Permission DefaultPermissions { get; }
    
    IAttachment? Icon { get; }
    
    IAttachment? Banner { get; }
    
    ServerFlag? Flags { get; }
    
    bool IsNsfw { get; }
    
    bool HasAnalyticsEnabled { get; }
    
    bool IsDiscoverable { get; }
}