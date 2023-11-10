namespace Rivoltante.Core;

public class CommonAttachment : IAttachment
{
    public CommonAttachment(AttachmentApiModel model)
    {
        Id = model.Id;
        Tag = model.Tag;
        Filename = model.Filename;
        // TODO: Metadata
        Metadata = null!;
        ContentType = model.ContentType;
        Size = model.Size;
        WasDeleted = model.Deleted.GetValueOrDefault();
        WasReported = model.Reported.GetValueOrDefault();
        MessageId = Optional<Ulid?>.ConvertOrDefault(model.MessageId, static id => Ulid.Parse(id));
        UserId = Optional<Ulid?>.ConvertOrDefault(model.UserId, static id => Ulid.Parse(id));
        ServerId = Optional<Ulid?>.ConvertOrDefault(model.ServerId, static id => Ulid.Parse(id));
        ObjectId = Optional<Ulid?>.ConvertOrDefault(model.ObjectId, static id => Ulid.Parse(id));
    }

    public string Id { get; }
    
    public string Tag { get; }
    
    public string Filename { get; }
    
    public IAttachmentMetadata Metadata { get; }
    
    public string ContentType { get; }
    
    public long Size { get; }
    
    public bool WasDeleted { get; }
    
    public bool WasReported { get; }
    
    public Ulid? MessageId { get; }
    
    public Ulid? UserId { get; }
    
    public Ulid? ServerId { get; }
    
    public Ulid ObjectId { get; }
}