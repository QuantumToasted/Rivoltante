namespace Rivoltante.Core;

public interface IAttachmentMetadata
{
    string Type { get; }
    AttachmentMetadataType? GetType() => Enum.TryParse(Type, out AttachmentMetadataType type) ? type : null;
}