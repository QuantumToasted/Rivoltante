namespace Rivoltante.Core;

public interface IMessageEmbedImage : IMessageEmbedMedia
{
    EmbedImageSize Size { get; }
}