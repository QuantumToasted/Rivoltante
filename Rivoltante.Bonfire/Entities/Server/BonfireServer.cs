using System.Collections.ObjectModel;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class BonfireServer : IBonfireServer
{
    public BonfireServer(IBonfireClient client, ServerCreateEventApiModel model)
    {
        Client = client;
        Update(model);
    }
    
    public IBonfireClient Client { get; }
    
    public Ulid Id { get; private set; }
    
    public Ulid OwnerId { get; private set; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }

    public IReadOnlyDictionary<Ulid, IServerChannel> Channels
    {
        get
        {
            if (Client.CacheProvider.TryGetChannels(Id, out var channels))
                return channels.ToDictionary(x => x.Key, x => (IServerChannel)x.Value);
            
            return ReadOnlyDictionary<Ulid, IServerChannel>.Empty;
        }
    }
    
    public IReadOnlyList<IBonfireServerChannelCategory> Categories { get; private set; }
    
    public Ulid? UserJoinedChannelId { get; private set; }
    
    public Ulid? UserLeftChannelId { get; private set; }
    
    public Ulid? UserKickedChannelId { get; private set; }
    
    public Ulid? UserBannedChannelId { get; private set; }
    
    public IReadOnlyDictionary<Ulid, IServerRole> Roles { get; private set; }
    
    public Permission DefaultPermissions { get; private set; }

    public IAttachment? Icon { get; private set; }
    
    public IAttachment? Banner { get; private set; }
    
    public ServerFlag? Flags { get; private set; }
    
    public bool IsNsfw { get; private set; }
    
    public bool HasAnalyticsEnabled { get; private set; }
    
    public bool IsDiscoverable { get; private set; }

    public void Update(ServerCreateEventApiModel model)
    {
        Id = model.Id;
        OwnerId = model.Owner;
        Name = model.Name;
        Description = model.Description.GetValueOrDefault();
    }

    public void Update(ServerUpdateEventApiModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(ServerRoleUpdateEventApiModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(ServerMemberLeaveApiModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(ServerMemberJoinEventApiModel model)
    {
        throw new NotImplementedException();
    }

    IReadOnlyList<Ulid> IServer.ChannelIds => Channels.Keys.ToList();
}