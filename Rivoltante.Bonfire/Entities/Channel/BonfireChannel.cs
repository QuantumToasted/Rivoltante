using Rivoltante.Core;

namespace Rivoltante.Bonfire.Channel;

public abstract class BonfireChannel(IBonfireClient client, ChannelCreateEventApiModel model) : IBonfireChannel
{
    public IBonfireClient Client { get; } = client;

    public Ulid Id { get; private protected set; } = model.Id;

    public ChannelType Type { get; private protected set; } = model.ChannelType;

    public abstract void Update(ChannelUpdateEventApiModel model);

    public abstract void Update(ChannelCreateEventApiModel model);
}