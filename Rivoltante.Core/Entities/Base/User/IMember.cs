namespace Rivoltante.Core;

public interface IMember : IServerEntity, IUlidEntity
{
    DateTimeOffset JoinedAt { get; }
    
    string? Nickname { get; }
    
    IAttachment? ServerAvatar { get; }
    
    IReadOnlyList<Ulid> RoleIds { get; }
    
    DateTimeOffset? TimedOutUntil { get; }
}