using Rivoltante.Core;

namespace Rivoltante.Bonfire.Channel;

public class BonfireVoiceChannel : BonfireServerChannel, IVoiceChannel
{
    public BonfireVoiceChannel(IBonfireClient client, ChannelCreateEventApiModel model) : base(client, model)
    {
        Update(model);
    }
    
    public sealed override void Update(ChannelCreateEventApiModel model)
    {
        Id = model.Id;
        Type = model.ChannelType;
        ServerId = model.Server.Value;
        Name = model.Name.Value;
        Description = model.Description.GetValueOrDefault();
        Icon = Optional<IAttachment>.ConvertOrDefault(model.Icon, x => new CommonAttachment(x));
        DefaultPermissions = Optional<IPermissionOverride>.ConvertOrDefault(model.DefaultPermissions, x => new CommonPermissionOverride(x.A, x.D));
        RolePermissions = Optional<IReadOnlyDictionary<Ulid, IPermissionOverride>>.ConvertOrFallback(model.RolePermissions,
            x => x.ToDictionary(y => y.Key, y => (IPermissionOverride)new CommonPermissionOverride(y.Value.A, y.Value.D)),
            new Dictionary<Ulid, IPermissionOverride>());
        IsNsfw = model.Nsfw.GetValueOrDefault();
    }

    public sealed override void Update(ChannelUpdateEventApiModel model)
    {
        var updateData = model.Data;

        if (updateData.Description.HasValue)
            Description = updateData.Description.Value;

        if (updateData.DefaultPermissions.HasValue)
            DefaultPermissions = new CommonPermissionOverride(updateData.DefaultPermissions.Value.A, updateData.DefaultPermissions.Value.D);

        if (updateData.RolePermissions.HasValue)
            RolePermissions = updateData.RolePermissions.Value.ToDictionary(x => x.Key,
                x => (IPermissionOverride)new CommonPermissionOverride(x.Value.A, x.Value.D));

        if (updateData.Nsfw.HasValue)
            IsNsfw = updateData.Nsfw.Value;

        if (updateData.Name.HasValue)
            Name = updateData.Name.Value;

        if (updateData.Icon.HasValue)
            Icon = new CommonAttachment(updateData.Icon.Value);

        foreach (var clear in model.Clear)
        {
            switch (clear)
            {
                case RemovedChannelField.Icon:
                    Icon = null;
                    break;
                case RemovedChannelField.Description:
                    Description = null;
                    break;
            }
        }
    }
}