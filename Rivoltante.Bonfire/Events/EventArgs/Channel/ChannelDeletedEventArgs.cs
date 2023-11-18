using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelDeletedEventArgs(Ulid channelId) : EventArgs
{
    public Ulid ChannelId { get; } = channelId;
}