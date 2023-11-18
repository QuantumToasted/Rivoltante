using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerDeletedEventArgs(Ulid serverId) : EventArgs
{
    public Ulid ServerId { get; } = serverId;
}