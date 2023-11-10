namespace Rivoltante.Core;

public class CommonMessageVideoEmbed : CommonMessageEmbed
{
    internal CommonMessageVideoEmbed(MessageVideoEmbedApiModel model)
        : base(model)
    {
        Url = model.Url;
        Width = model.Width;
        Height = model.Height;
    }
    
    public string Url { get; }
    
    public int Width { get; }
    
    public int Height { get; }
}