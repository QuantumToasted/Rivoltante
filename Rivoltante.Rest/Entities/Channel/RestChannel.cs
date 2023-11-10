using Rivoltante.Core;

namespace Rivoltante.Rest;

public abstract class RestChannel(ChannelApiModel model, IRevoltClient client) : IChannel
{
    public Ulid Id { get; } = model.Id;

    public IRevoltClient Client { get; } = client;

    public ChannelType Type { get; } = model.ChannelType;

    public static RestChannel Create(ChannelApiModel model, IRevoltClient client)
    {
        return model.ChannelType switch
        {
            ChannelType.SavedMessages => new RestSavedMessageChannel(model, client),
            ChannelType.DirectMessage => new RestDirectMessageChannel(model, client),
            ChannelType.Group => new RestGroupChannel(model, client),
            ChannelType.TextChannel => new RestTextChannel(model, client),
            ChannelType.VoiceChannel => new RestVoiceChannel(model, client),
            _ => new RestUnknownChannel(model, client)
        };
    }
}