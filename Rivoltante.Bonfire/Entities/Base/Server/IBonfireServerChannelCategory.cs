using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireServerChannelCategory : IServerChannelCategory
{
    Dictionary<Ulid, IServerChannel> Channels { get; }

    IReadOnlyList<Ulid> IServerChannelCategory.ChannelIds => Channels.Keys.ToList();
}