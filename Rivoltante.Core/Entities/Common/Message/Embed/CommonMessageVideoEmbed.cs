namespace Rivoltante.Core;

public class CommonMessageVideoEmbed(MessageEmbedApiModel model) : CommonMessageEmbed
{
    public string Url { get; } = model.Url.Value;

    public int Width { get; } = model.Width.Value;

    public int Height { get; } = model.Height.Value;

    public override EmbedType Type => EmbedType.Video;
}