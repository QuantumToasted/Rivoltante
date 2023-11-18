using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageDeletedEventArgs(Ulid messageId, Ulid channelId) : EventArgs
{
    public Ulid MessageId { get; } = messageId;

    public Ulid ChannelId { get; } = channelId;
    
    // public IMessage? Message { get; } TODO: cache
}