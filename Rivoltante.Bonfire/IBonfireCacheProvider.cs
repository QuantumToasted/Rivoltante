using System.Collections.Concurrent;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireCacheProvider
{
    bool Supports<TEntity>();

    bool TryGetCache<TEntity>(out ConcurrentDictionary<Ulid, TEntity> cache);

    bool TryGetCache<TEntity>(Ulid parentId, out ConcurrentDictionary<Ulid, TEntity> cache, bool lookupOnly = false);

    bool TryRemoveCache<TEntity>(Ulid parentId, out ConcurrentDictionary<Ulid, TEntity> cache);

    void Reset();

    //void Reset(Ulid serverId, out BonfireServer? server);
}