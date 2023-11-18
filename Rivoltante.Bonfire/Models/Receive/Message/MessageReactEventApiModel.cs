using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageReactEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public required Ulid ChannelId { get; init; }

    public required Ulid UserId { get; init; }

    public required string EmojiId { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.MessageReact;
}