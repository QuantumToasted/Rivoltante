namespace Rivoltante.Core;

public class CommonMessageEmbedImage(MessageEmbedImageApiModel model) : IMessageEmbedImage
{
    public string Url { get; } = model.Url;

    public int Width { get; } = model.Width;

    public int Height { get; } = model.Height;

    public EmbedImageSize Size { get; } = model.Size;
}