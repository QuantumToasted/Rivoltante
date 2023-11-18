namespace Rivoltante.Core;

public sealed class AttachmentMetadataApiModel : IApiModel
{
    public required string Type { get; init; }
    
    public Optional<int> Width { get; init; }
    
    public Optional<int> Height { get; init; }
}