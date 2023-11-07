using Rivoltante.Core;

namespace Rivoltante.Rest.Message;

public class RestMessageVideoEmbed : RestMessageEmbed
{
    internal RestMessageVideoEmbed(MessageVideoEmbedApiModel model)
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