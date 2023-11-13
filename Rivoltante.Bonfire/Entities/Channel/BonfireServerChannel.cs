using Rivoltante.Core;

namespace Rivoltante.Bonfire.Channel;

public abstract class BonfireServerChannel : BonfireChannel, IBonfireServerChannel
{
    public BonfireServerChannel(IBonfireClient client, ChannelCreateEventApiModel model) 
        : base(client, model)
    { }

    public Ulid ServerId { get; private protected set; }
    
    public string Name { get; private protected set; }
    
    public string? Description { get; private protected set; }
    
    public IAttachment? Icon { get; private protected set; }

    public IPermissionOverride? DefaultPermissions { get; private protected set; }

    public IReadOnlyDictionary<Ulid, IPermissionOverride> RolePermissions { get; private protected set; }
    
    public bool IsNsfw { get; private protected set; }
}