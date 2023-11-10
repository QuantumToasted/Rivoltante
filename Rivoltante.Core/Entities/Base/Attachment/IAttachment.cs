namespace Rivoltante.Core;

public interface IAttachment
{
    string Id { get; }
    
    string Tag { get; }
    
    string Filename { get; }
    
    IAttachmentMetadata Metadata { get; }
    
    string ContentType { get; }
    
    long Size { get; }
    
    bool WasDeleted { get; }
    
    bool WasReported { get; }
    
    Ulid? MessageId { get; }
    
    Ulid? UserId { get; }
    
    Ulid? ServerId { get; }
    
    Ulid ObjectId { get; }
}