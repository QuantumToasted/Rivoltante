namespace Rivoltante.Core;

public abstract class CommonChannel(ChannelApiModel model, IRevoltClient client) : IChannel
{
    public IRevoltClient Client { get; } = client;

    public Ulid Id { get; } = model.Id;

    public abstract ChannelType Type { get; }

    public static CommonChannel Create(ChannelApiModel model, IRevoltClient client)
    {
        ChannelType? type = Enum.TryParse(model.ChannelType, out ChannelType t)
            ? t
            : null;
        
        return type switch
        {
            ChannelType.SavedMessages => new CommonSavedMessageChannel(model, client),
            ChannelType.DirectMessage => new CommonDirectMessageChannel(model, client),
            ChannelType.Group => new CommonGroupChannel(model, client),
            ChannelType.TextChannel => new CommonTextChannel(model, client),
            ChannelType.VoiceChannel => new CommonVoiceChannel(model, client),
            _ => new CommonUnknownChannel(model, client)
        };
    }
}