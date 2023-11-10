using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed class RestSavedMessageChannel(ChannelApiModel model, IRevoltClient client) : RestChannel(model, client),
    ISavedMessageChannel
{
    public Ulid UserId { get; } = model.User.Value;
}