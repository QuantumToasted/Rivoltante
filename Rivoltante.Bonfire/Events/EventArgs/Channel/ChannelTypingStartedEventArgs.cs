using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelTypingStartedEventArgs(Ulid channelId, Ulid userId) : EventArgs
{
    public Ulid ChannelId { get; } = channelId;
    
    public Ulid UserId { get; } = userId;
}