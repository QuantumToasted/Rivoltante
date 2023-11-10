namespace Rivoltante.Core;

public sealed class CommonTextChannel(ChannelApiModel model, IRevoltClient client) : CommonChannel(model, client), ITextChannel
{
    public Ulid ServerId { get; } = model.Server.Value;

    public string Name { get; } = model.Name.Value;

    public string? Description { get; } = model.Description.GetValueOrDefault();
    
    public IAttachment? Icon { get; } = Optional<IAttachment>.ConvertOrDefault(model.Icon, x => new CommonAttachment(x));

    public IPermissionOverride? DefaultPermissions { get; } = model.DefaultPermissions.HasValue
        ? new CommonPermissionOverride(model.DefaultPermissions.Value.A, model.DefaultPermissions.Value.D)
        : null;

    public IReadOnlyDictionary<Ulid, IPermissionOverride> RolePermissions { get; } = model.RolePermissions.GetValueOrDefault()?.ToDictionary(
                                                                                         x => Ulid.Parse(x.Key),
                                                                                         x => (IPermissionOverride)new CommonPermissionOverride(
                                                                                             x.Value.A, x.Value.D))
                                                                                     ?? new Dictionary<Ulid, IPermissionOverride>();

    public bool IsNsfw { get; } = model.Nsfw.GetValueOrDefault();

    public Ulid? LastMessageId { get; } = model.LastMessageId.GetValueOrDefault();
}