using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class EmojiCreatedEventArgs(IServerEmoji emoji) : EventArgs
{
    public IServerEmoji Emoji { get; } = emoji;

    public Ulid CreatorId => Emoji.CreatorId;

    public Ulid? ServerId => Emoji.ServerId;
}