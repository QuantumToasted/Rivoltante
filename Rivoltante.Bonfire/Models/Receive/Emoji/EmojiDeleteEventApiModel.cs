using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class EmojiDeleteEventApiModel : IReceiveEventApiModel
{
    public Ulid Id { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.EmojiDelete;
}