namespace Rivoltante.Core;

public interface IMessageEmbedMedia
{
    string Url { get; }
    
    int Width { get; }
    
    int Height { get; }
}