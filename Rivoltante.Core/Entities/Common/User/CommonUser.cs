namespace Rivoltante.Core;

public class CommonUser(UserApiModel model, IRevoltClient client) : IUser
{
    public IRevoltClient Client { get; } = client;
    
    public Ulid Id { get; } = model.Id;
    
    public string Username { get; } = model.Username;
    
    public string Discriminator { get; } = model.Discriminator;
    
    public string? DisplayName { get; } = model.DisplayName.GetValueOrDefault();
    
    public IAttachment? Avatar { get; } = Optional<IAttachment>.ConvertOrDefault(model.Avatar, x => new CommonAttachment(x));

    public IReadOnlyDictionary<Ulid, UserRelationshipStatus> Relationships { get; } =
        Optional<IReadOnlyDictionary<Ulid, UserRelationshipStatus>>.ConvertOrFallback(
            model.Relations,
            x => x.ToDictionary(y => y.Id, y => y.Status), new Dictionary<Ulid, UserRelationshipStatus>());
    
    public UserBadge? Badges { get; } = model.Badges.GetValueOrNullable();
    
    public IUserStatus? Status { get; } = Optional<IUserStatus>.ConvertOrDefault(model.Status, x => new CommonUserStatus(x));
    
    public UserFlag? Flags { get; } = model.Flags.GetValueOrNullable();
    
    public bool IsPrivileged { get; } = model.Privileged.GetValueOrDefault();
    
    public Ulid? BotOwnerId { get; } = model.Bot.GetValueOrDefault()?.Owner;
    
    public UserRelationshipStatus? CurrentUserRelationship { get; } = model.Relationship.GetValueOrNullable();
    
    public bool IsOnline { get; } = model.Online.GetValueOrDefault();

    public bool IsBot => BotOwnerId.HasValue;
}