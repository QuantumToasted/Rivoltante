namespace Rivoltante.Core;

public abstract class CommonInvite(InviteApiModel model, IRevoltClient client) : IInvite
{
    public IRevoltClient Client { get; } = client;
    
    public Ulid ChannelId { get; } = model.Channel;
    
    public abstract InviteType Type { get; }
    
    public string InviteCode { get; } = model.Id;
    
    public Ulid CreatorId { get; } = model.Creator;

    public static CommonInvite Create(InviteApiModel model, IRevoltClient client)
    {
        InviteType? type = Enum.TryParse(model.Type, out InviteType t)
            ? t
            : null;
        
        return type switch
        {
            InviteType.Group => new CommonGroupInvite(model, client),
            InviteType.Server => new CommonServerInvite(model, client),
            _ => new CommonUnknownInvite(model, client)
        };
    }
}