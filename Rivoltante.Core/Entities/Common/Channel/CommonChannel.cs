namespace Rivoltante.Core;

public abstract class CommonChannel(ChannelApiModel model, IRevoltClient client) : IChannel
{
    public Ulid Id { get; } = model.Id;

    public IRevoltClient Client { get; } = client;

    public ChannelType Type { get; } = model.ChannelType;

    public static CommonChannel Create(ChannelApiModel model, IRevoltClient client)
    {
        return model.ChannelType switch
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