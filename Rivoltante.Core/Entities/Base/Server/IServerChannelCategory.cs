namespace Rivoltante.Core;

public interface IServerChannelCategory
{
    Ulid Id { get; }
    
    string Title { get; }
    
    IReadOnlyList<Ulid> ChannelIds { get; }
}