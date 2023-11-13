using System.Collections.Concurrent;
using System.Collections.Frozen;
using Rivoltante.Bonfire.Channel;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public static class CacheProviderExtensions
{
    public static bool TryGetChannels(this IBonfireCacheProvider cacheProvider, Ulid serverId,
        out ConcurrentDictionary<Ulid, BonfireServerChannel> cache, bool lookupOnly = false)
    {
        return cacheProvider.TryGetCache(serverId, out cache, lookupOnly);
    }
    
    public static bool TryGetUsers(this IBonfireCacheProvider cacheProvider, Ulid channelId, out ConcurrentDictionary<Ulid, BonfireUser> cache, bool lookupOnly = false)
    {
        return cacheProvider.TryGetCache(channelId, out cache, lookupOnly);
    }

    public static bool TryGetUsers(this IBonfireCacheProvider cacheProvider, out ConcurrentDictionary<Ulid, BonfireUser> cache)
    {
        return cacheProvider.TryGetCache(out cache);
    }
}