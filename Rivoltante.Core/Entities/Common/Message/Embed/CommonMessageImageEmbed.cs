namespace Rivoltante.Core;

public class CommonMessageImageEmbed : CommonMessageEmbed
{
    internal CommonMessageImageEmbed(MessageImageEmbedApiModel model)
        : base(model)
    {
        Url = model.Url;
        Width = model.Width;
        Height = model.Height;
        Size = Enum.TryParse<ImageSize>(model.Size, out var size) ? size : ImageSize.Unknown;
    }
    
    public string Url { get; }
    
    public int Width { get; }
    
    public int Height { get; }
    
    public ImageSize Size { get; }
}