namespace Rivoltante.Core;

public abstract class CommonInvite(InviteApiModel model, IRevoltClient client) : IInvite
{
    public IRevoltClient Client { get; } = client;
    
    public Ulid ChannelId { get; } = model.Channel;
    
    public InviteType Type { get; } = model.Type;
    
    public string InviteCode { get; } = model.Id;
    
    public Ulid CreatorId { get; } = model.Creator;

    public static IInvite Create(InviteApiModel model, IRevoltClient client)
    {
        return model.Type switch
        {
            InviteType.Group => new CommonGroupInvite(model, client),
            InviteType.Server => new CommonServerInvite(model, client),
            _ => new CommonUnknownInvite(model, client)
        };
    }
}