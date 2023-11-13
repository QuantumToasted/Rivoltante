using System.Collections.ObjectModel;
using Rivoltante.Core;

namespace Rivoltante.Bonfire.Channel;

public abstract class BonfirePrivateChannel(IBonfireClient client, ChannelCreateEventApiModel model) : BonfireChannel(client, model),
    IBonfirePrivateChannel
{
    public Ulid? LastMessageId { get; private protected set; }

    public IReadOnlyDictionary<Ulid, IBonfireUser> Recipients
    {
        get
        {
            if (Client.CacheProvider.TryGetUsers(Id, out var users))
                return users.ToDictionary(x => x.Key, x => (IBonfireUser) x.Value);

            return ReadOnlyDictionary<Ulid, IBonfireUser>.Empty;
        }
    }
}