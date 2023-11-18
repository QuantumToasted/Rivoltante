namespace Rivoltante.Core;

public sealed class CommonAttachmentMetadata(AttachmentMetadataApiModel model) : IAttachmentMetadata
{
    public string Type { get; } = model.Type;

    public int? Width { get; } = model.Width.GetValueOrNullable();

    public int? Height { get; } = model.Height.GetValueOrNullable();
}