using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using Rivoltante.Core;

namespace Rivoltante.WebSocket;

public interface IRevoltWebSocketCache
{
    bool TryGetCache<TEntity>([MaybeNullWhen(false)] out ConcurrentDictionary<Ulid, TEntity> cache);

    bool TryGetCache<TEntity>(Ulid parentId, [MaybeNullWhen(false)] out ConcurrentDictionary<Ulid, TEntity> cache);

    void Reset();
}