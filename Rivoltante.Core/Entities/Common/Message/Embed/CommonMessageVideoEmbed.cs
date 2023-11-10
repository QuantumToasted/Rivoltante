namespace Rivoltante.Core;

public class CommonMessageVideoEmbed : CommonMessageEmbed
{
    internal CommonMessageVideoEmbed(MessageEmbedApiModel model)
        : base(model)
    {
        Url = model.Url.Value;
        Width = model.Width.Value;
        Height = model.Height.Value;
    }
    
    public string Url { get; }
    
    public int Width { get; }
    
    public int Height { get; }
}