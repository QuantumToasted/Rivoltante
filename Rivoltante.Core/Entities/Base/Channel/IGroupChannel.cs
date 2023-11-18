namespace Rivoltante.Core;

public interface IGroupChannel : IPrivateChannel, INamedEntity
{
    Ulid OwnerId { get; }
    
    string? Description { get; }
    
    IAttachment? Icon { get; }
    
    Permission? Permissions { get; }
    
    bool IsNsfw { get; }
}