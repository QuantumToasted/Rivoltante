namespace Rivoltante.Core;

public class CommonMessageEmbedVideo(MessageEmbedVideoApiModel model) : IMessageEmbedVideo
{
    public string Url { get; } = model.Url;

    public int Width { get; } = model.Width;

    public int Height { get; } = model.Height;
}