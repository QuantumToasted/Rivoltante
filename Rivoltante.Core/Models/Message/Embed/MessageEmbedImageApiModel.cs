namespace Rivoltante.Core;

public sealed class MessageEmbedImageApiModel : IApiModel
{
    public required string Url { get; init; }
    
    public required int Width { get; init; }
    
    public required int Height { get; init; }
    
    public required EmbedImageSize Size { get; init; }
}