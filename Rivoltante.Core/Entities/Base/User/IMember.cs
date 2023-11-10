namespace Rivoltante.Core;

public interface IMember : IUser, IServerEntity
{
    DateTimeOffset JoinedAt { get; }
    
    string? Nickname { get; }
    
    IAttachment? ServerAvatar { get; }
    
    IReadOnlyList<Ulid> RoleIds { get; }
    
    DateTimeOffset? TimedOutUntil { get; }
}