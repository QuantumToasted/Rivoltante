namespace Rivoltante.Core;

public sealed class CommonAttachment(AttachmentApiModel model) : IAttachment
{
    public string Id { get; } = model.Id;

    public string Tag { get; } = model.Tag;

    public string Filename { get; } = model.Tag;

    public IAttachmentMetadata Metadata { get; } = new CommonAttachmentMetadata(model.Metadata);

    public string ContentType { get; } = model.ContentType;

    public long Size { get; } = model.Size;

    public bool WasDeleted { get; } = model.Deleted.GetValueOrDefault();

    public bool WasReported { get; } = model.Reported.GetValueOrDefault();

    public Ulid? MessageId { get; } = model.MessageId.GetValueOrNullable();

    public Ulid? UserId { get; } = model.UserId.GetValueOrNullable();

    public Ulid? ServerId { get; } = model.ServerId.GetValueOrNullable();

    public string? ObjectId { get; } = model.ObjectId.GetValueOrDefault();
}