namespace Rivoltante.Core;

public sealed class CommonSavedMessageChannel(ChannelApiModel model, IRevoltClient client) : CommonChannel(model, client),
    ISavedMessageChannel
{
    public Ulid UserId { get; } = model.User.Value;
}