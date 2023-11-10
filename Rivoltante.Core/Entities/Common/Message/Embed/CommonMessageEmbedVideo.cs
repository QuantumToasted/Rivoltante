namespace Rivoltante.Core;

public class CommonMessageEmbedVideo : IMessageEmbedVideo
{
    public CommonMessageEmbedVideo(MessageEmbedVideoApiModel model)
    {
        Url = model.Url;
        Width = model.Width;
        Height = model.Height;
    }

    public string Url { get; }
    
    public int Width { get; }
    
    public int Height { get; }
}