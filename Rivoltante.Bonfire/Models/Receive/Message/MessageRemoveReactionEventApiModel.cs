using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageRemoveReactionEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public required Ulid ChannelId { get; init; }

    public required string EmojiId { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.MessageRemoveReaction;
}