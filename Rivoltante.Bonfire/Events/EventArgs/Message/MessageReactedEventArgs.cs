using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageReactedEventArgs(Ulid messageId, Ulid channelId, Ulid userId, IEmoji emoji) : EventArgs
{
    public Ulid MessageId { get; } = messageId;
    
    public Ulid ChannelId { get; } = channelId;
    
    public Ulid UserId { get; } = userId;
    
    public IEmoji Emoji { get; } = emoji;
}