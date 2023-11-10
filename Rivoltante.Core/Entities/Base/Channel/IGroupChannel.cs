namespace Rivoltante.Core;

public interface IGroupChannel : IPrivateChannel
{
    string Name { get; }
    
    Ulid OwnerId { get; }
    
    string? Description { get; }
    
    IAttachment? Icon { get; }
    
    Permissions? Permissions { get; }
    
    bool IsNsfw { get; }
}