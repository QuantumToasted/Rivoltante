using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class CreateChannelRequestApiModel : IApiModel
{
    public required string Type { get; init; }
    
    public required string Name { get; init; }

    public Optional<string> Description { get; init; }

    public Optional<bool> Nsfw { get; init; }
}