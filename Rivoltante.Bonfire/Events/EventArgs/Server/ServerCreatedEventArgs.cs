using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerCreatedEventArgs(IServer server) : EventArgs
{
    public IServer Server { get; } = server;

    public Ulid ServerId => Server.Id;
}