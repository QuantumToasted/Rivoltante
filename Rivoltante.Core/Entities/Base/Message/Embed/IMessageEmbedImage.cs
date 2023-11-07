namespace Rivoltante.Core;

public interface IMessageEmbedImage : IMessageEmbedMedia
{
    ImageSize Size { get; }
}