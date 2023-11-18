namespace Rivoltante.Core;

public class CommonMessageImageEmbed(MessageEmbedApiModel model) : CommonMessageEmbed
{
    public string Url { get; } = model.Url.Value;

    public int Width { get; } = model.Width.Value;

    public int Height { get; } = model.Height.Value;

    public EmbedImageSize Size { get; } = model.Size.Value;

    public override EmbedType Type => EmbedType.Image;
}