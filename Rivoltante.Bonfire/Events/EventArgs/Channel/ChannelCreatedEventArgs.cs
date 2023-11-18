using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelCreatedEventArgs(IChannel channel) : EventArgs
{
    public IChannel Channel { get; } = channel;
}