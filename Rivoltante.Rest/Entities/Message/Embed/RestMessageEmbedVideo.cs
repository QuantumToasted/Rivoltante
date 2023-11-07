using Rivoltante.Core;

namespace Rivoltante.Rest.Message;

public class RestMessageEmbedVideo : IMessageEmbedVideo
{
    public RestMessageEmbedVideo(MessageEmbedVideoApiModel model)
    {
        Url = model.Url;
        Width = model.Width;
        Height = model.Height;
    }

    public string Url { get; }
    
    public int Width { get; }
    
    public int Height { get; }
}