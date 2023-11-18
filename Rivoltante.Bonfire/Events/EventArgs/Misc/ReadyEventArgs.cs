using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ReadyEventArgs(IEnumerable<IUser> users, IEnumerable<IServer> servers, IEnumerable<IChannel> channels, IEnumerable<ICustomEmoji> emojis) 
    : EventArgs
{
    public IReadOnlyDictionary<Ulid, IUser> Users { get; } = users.ToDictionary(x => x.Id);

    public IReadOnlyDictionary<Ulid, IServer> Servers { get; } = servers.ToDictionary(x => x.Id);

    public IReadOnlyDictionary<Ulid, IChannel> Channels { get; } = channels.ToDictionary(x => x.Id);

    public IReadOnlyDictionary<Ulid, ICustomEmoji> Emojis { get; } = emojis.ToDictionary(x => x.Id);
}