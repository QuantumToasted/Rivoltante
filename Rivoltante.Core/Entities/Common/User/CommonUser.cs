namespace Rivoltante.Core;

public class CommonUser : IUser
{
    public CommonUser(UserApiModel model, IRevoltClient client)
    {
        Id = model.Id;
        Client = client;
        Username = model.Username;
        Discriminator = model.Discriminator;
        DisplayName = model.DisplayName.GetValueOrDefault();
        Avatar = Optional<IAttachment>.ConvertOrDefault(model.Avatar, x => new CommonAttachment(x));
        Relationships = Optional<IReadOnlyDictionary<Ulid, UserRelationshipStatus>>.ConvertOrFallback(
            model.Relations,
            x => x.ToDictionary(y => y.Id, y => y.Status), new Dictionary<Ulid, UserRelationshipStatus>());
        Badges = model.Badges.GetValueOrNullable();
        Status = Optional<IUserStatus>.ConvertOrDefault(model.Status, x => new CommonUserStatus(x));
        Flags = model.Flags.GetValueOrNullable();
        IsPrivileged = model.Privileged;
        BotOwnerId = model.Bot.GetValueOrDefault()?.Owner;
        CurrentUserRelationship = model.Relationship.GetValueOrNullable();
        IsOnline = model.Online.GetValueOrDefault();
    }
    
    public Ulid Id { get; }
    
    public IRevoltClient Client { get; }
    
    public string Username { get; }
    
    public string Discriminator { get; }
    
    public string? DisplayName { get; }
    
    public IAttachment? Avatar { get; }
    
    public IReadOnlyDictionary<Ulid, UserRelationshipStatus> Relationships { get; }
    
    public UserBadge? Badges { get; }
    
    public IUserStatus? Status { get; }
    
    public UserFlag? Flags { get; }
    
    public bool IsPrivileged { get; }
    
    public Ulid? BotOwnerId { get; }
    
    public UserRelationshipStatus? CurrentUserRelationship { get; }
    
    public bool IsOnline { get; }
}