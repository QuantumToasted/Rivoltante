namespace Rivoltante.Core;

public interface IServerChannelCategory
{
    string Id { get; }
    
    string Title { get; }
    
    IReadOnlyList<Ulid> ChannelIds { get; }
}