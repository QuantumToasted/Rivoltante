using Rivoltante.Core;
using Rivoltante.Rest.Message;

namespace Rivoltante.Rest;

public sealed class RestTextChannel(ChannelApiModel model, IRevoltClient client) : RestChannel(model, client), ITextChannel
{
    /*
    public RestTextChannel : base(model, client)
    {
        ServerId = model.Server;
        Name = model.Name;
        Description = model.Description;
        Icon = model.Icon is not null ? new RestAttachment(model.Icon) : null;
        DefaultPermissions = model.DefaultPermissions is not null
            ? new CommonPermissionOverride((Permissions) model.DefaultPermissions.A, (Permissions) model.DefaultPermissions.D)
            : null;
        RolePermissions = model.RolePermissions?.ToDictionary(x => Ulid.Parse(x.Key),
                              x => (IPermissionOverride)new CommonPermissionOverride((Permissions)x.Value.A, (Permissions)x.Value.D)) ??
                          new Dictionary<Ulid, IPermissionOverride>();
        IsNsfw = model.Nsfw;
        LastMessageId = model.LastMessageId is not null ? model.LastMessageId : (Ulid?)null;
    }
    */

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

    public Ulid? LastMessageId { get; } = model.LastMessageId.GetValueOrDefault();
}