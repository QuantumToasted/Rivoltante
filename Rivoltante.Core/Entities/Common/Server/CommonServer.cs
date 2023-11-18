namespace Rivoltante.Core;

public sealed class CommonServer(ServerApiModel model, IRevoltClient client) : IServer
{
    public IRevoltClient Client { get; } = client;

    public Ulid Id { get; } = model.Id;

    public string Name { get; } = model.Name;

    public Ulid OwnerId { get; } = model.Owner;

    public string? Description { get; } = model.Description.GetValueOrDefault();

    public IReadOnlyList<Ulid> ChannelIds { get; } = model.Channels;

    public IReadOnlyList<IServerChannelCategory> Categories { get; } =
        Optional<IReadOnlyList<IServerChannelCategory>>.ConvertOrFallback<ServerChannelCategoryApiModel[], IReadOnlyList<IServerChannelCategory>>(
            model.Categories, x => x.Select(y => new CommonServerChannelCategory(y)).ToList(), new List<IServerChannelCategory>());

    public IReadOnlyDictionary<SystemMessageType, Ulid> SystemMessageChannelIds
    {
        get
        {
            var dict = new Dictionary<SystemMessageType, Ulid>();

            if (model.SystemMessages is { HasValue: true, Value: var systemMessages })
            {
                if (systemMessages.UserJoined.HasValue)
                    dict[SystemMessageType.UserJoined] = systemMessages.UserJoined.Value;

                if (systemMessages.UserLeft.HasValue)
                    dict[SystemMessageType.UserLeft] = systemMessages.UserLeft.Value;
                
                if (systemMessages.UserKicked.HasValue)
                    dict[SystemMessageType.UserKicked] = systemMessages.UserKicked.Value;
                
                if (systemMessages.UserBanned.HasValue)
                    dict[SystemMessageType.UserBanned] = systemMessages.UserBanned.Value;
            }

            return dict;
        }
    }

    public IReadOnlyDictionary<Ulid, IServerRole> Roles { get; } =
        Optional<IReadOnlyDictionary<Ulid, IServerRole>>
            .ConvertOrFallback<Dictionary<Ulid, ServerRoleApiModel>, IReadOnlyDictionary<Ulid, IServerRole>>(model.Roles,
                x => x.ToDictionary(y => y.Key, y => (IServerRole)new CommonServerRole(model.Id, y.Key, y.Value, client)),
                new Dictionary<Ulid, IServerRole>());

    public Permission DefaultPermissions { get; } = model.DefaultPermissions;

    public IAttachment? Icon { get; } = Optional<IAttachment>.ConvertOrDefault(model.Icon, x => new CommonAttachment(x));
    
    public IAttachment? Banner { get; } = Optional<IAttachment>.ConvertOrDefault(model.Banner, x => new CommonAttachment(x));

    public ServerFlag? Flags { get; } = model.Flags.GetValueOrNullable();

    public bool IsNsfw { get; } = model.Nsfw.GetValueOrDefault();

    public bool HasAnalyticsEnabled { get; } = model.Analytics.GetValueOrDefault();

    public bool IsDiscoverable { get; } = model.Discoverable.GetValueOrDefault();
}