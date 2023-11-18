namespace Rivoltante.Core;

public interface IUser : IUlidEntity
{
    string Username { get; }
    
    string Discriminator { get; }
    
    string? DisplayName { get; }
    
    IAttachment? Avatar { get; }
    
    IReadOnlyDictionary<Ulid, UserRelationshipStatus> Relationships { get; }
    
    UserBadge? Badges { get; }
    
    IUserStatus? Status { get; }
    
    UserFlag? Flags { get; }
    
    bool IsPrivileged { get; }
    
    Ulid? BotOwnerId { get; }
    
    UserRelationshipStatus? CurrentUserRelationship { get; }
    
    bool IsOnline { get; }

    bool IsBot => BotOwnerId.HasValue;
}