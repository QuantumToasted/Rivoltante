namespace Rivoltante.Core;

public class MessageEmbedVideoApiModel : IApiModel
{
    public required string Url { get; init; }
    
    public required int Width { get; init; }
    
    public required int Height { get; init; }
}