using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessagesAcknowledgedEventArgs(Ulid channelId, Ulid userId, Ulid messageId) : EventArgs
{
    public Ulid ChannelId { get; } = channelId;
    
    public Ulid UserId { get; } = userId;
    
    public Ulid MessageId { get; } = messageId;
}