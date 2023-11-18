namespace Rivoltante.Core;

public interface IServerEmoji : IRevoltEntity, ICustomEmoji, INamedEntity
{
    Ulid? ServerId { get; }
    
    Ulid CreatorId { get; }
    
    bool IsAnimated { get; }
    
    bool IsNsfw { get; }
}