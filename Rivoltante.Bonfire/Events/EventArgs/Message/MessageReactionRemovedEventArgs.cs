using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageReactionRemovedEventArgs(Ulid messageId, Ulid channelId, IEmoji emoji) : EventArgs
{
    public Ulid MessageId { get; } = messageId;
    
    public Ulid ChannelId { get; } = channelId;
    
    public IEmoji Emoji { get; } = emoji;
}