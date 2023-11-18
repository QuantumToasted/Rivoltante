using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class EmojiDeletedEventArgs(Ulid emojiId) : EventArgs
{
    public Ulid EmojiId { get; } = emojiId;
}