namespace Rivoltante.Core;

public sealed class CommonDirectMessageChannel(ChannelApiModel model, IRevoltClient client) : CommonChannel(model, client), IDirectMessageChannel
{
    public bool IsActive { get; } = model.Active.GetValueOrDefault();

    public IReadOnlyList<Ulid> RecipientIds { get; } = model.Recipients.GetValueOrFallback(Array.Empty<Ulid>());

    public Ulid? LastMessageId { get; } = model.LastMessageId.GetValueOrDefault();
}