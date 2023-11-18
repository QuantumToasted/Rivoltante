namespace Rivoltante.Core;

public abstract class CommonServerChannel(ChannelApiModel model, IRevoltClient client) : CommonChannel(model, client), IServerChannel
{
    public Ulid ServerId { get; } = model.Server.Value;

    public string Name { get; } = model.Name.Value;

    public string? Description { get; } = model.Description.GetValueOrDefault();
    
    public IAttachment? Icon { get; } = Optional<IAttachment>.ConvertOrDefault(model.Icon, x => new CommonAttachment(x));

    public IPermissions? DefaultPermissions { get; } = model.DefaultPermissions.HasValue
        ? new CommonPermissions(model.DefaultPermissions.Value)
        : null;

    public IReadOnlyDictionary<Ulid, IPermissions> RolePermissions { get; } =
        model.RolePermissions.GetValueOrDefault()?.ToDictionary(
            x => Ulid.Parse(x.Key),
            x => (IPermissions)new CommonPermissions(x.Value))
        ?? new Dictionary<Ulid, IPermissions>();

    public bool IsNsfw { get; } = model.Nsfw.GetValueOrDefault();
}