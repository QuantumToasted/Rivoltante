using Rivoltante.Core;
using Rivoltante.Rest.Message;

namespace Rivoltante.Rest;

public sealed class RestVoiceChannel(ChannelApiModel model, IRevoltClient client) : RestChannel(model, client), IVoiceChannel
{
    public Ulid ServerId { get; } = model.Server.Value;

    public string Name { get; } = model.Name.Value;

    public string? Description { get; } = model.Description.GetValueOrDefault();
    
    public IAttachment? Icon { get; } = model.Icon.HasValue ? new RestAttachment(model.Icon.Value) : null;

    public IPermissionOverride? DefaultPermissions { get; } = model.DefaultPermissions.HasValue
        ? new CommonPermissionOverride(model.DefaultPermissions.Value.A, model.DefaultPermissions.Value.D)
        : null;

    public IReadOnlyDictionary<Ulid, IPermissionOverride> RolePermissions { get; } = model.RolePermissions.GetValueOrDefault()?.ToDictionary(
                                                                                         x => Ulid.Parse(x.Key),
                                                                                         x => (IPermissionOverride)new CommonPermissionOverride(
                                                                                             x.Value.A, x.Value.D))
                                                                                     ?? new Dictionary<Ulid, IPermissionOverride>();

    public bool IsNsfw { get; } = model.Nsfw.GetValueOrDefault();
}