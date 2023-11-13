using Rivoltante.Core;

namespace Rivoltante.Bonfire.Channel;

public interface IBonfirePrivateChannel : IBonfireChannel, IPrivateChannel
{
    IReadOnlyDictionary<Ulid, IBonfireUser> Recipients { get; }

    IReadOnlyList<Ulid> IPrivateChannel.RecipientIds => Recipients.Keys.ToList();
}