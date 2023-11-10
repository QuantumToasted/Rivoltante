using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed class RestDirectMessageChannel(ChannelApiModel model, IRevoltClient client) : RestChannel(model, client), IDirectMessageChannel
{
    public bool IsActive { get; } = model.Active.GetValueOrDefault();

    public IReadOnlyList<Ulid> RecipientIds { get; } = model.Recipients.GetValueOrFallback(Array.Empty<Ulid>());

    public Ulid? LastMessageId { get; } = model.LastMessageId.GetValueOrDefault();
}