using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class CreateServerRequestApiModel : IApiModel
{
    public required string Name { get; init; }
    
    public Optional<string> Description { get; init; }
    
    public Optional<bool> Nsfw { get; init; }
}