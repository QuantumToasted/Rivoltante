namespace Rivoltante.Core;

public interface IMessageAttachment : IIdentifiableEntity
{
    string Tag { get; }
    
    string Filename { get; }
    
    IMessageAttachmentMetadata Metadata { get; }
    
    string ContentType { get; }
    
    long Size { get; }
    
    bool WasDeleted { get; }
    
    bool WasReported { get; }
    
    Ulid? MessageId { get; }
    
    Ulid? UserId { get; }
    
    Ulid? ServerId { get; }
    
    Ulid ObjectId { get; }
}