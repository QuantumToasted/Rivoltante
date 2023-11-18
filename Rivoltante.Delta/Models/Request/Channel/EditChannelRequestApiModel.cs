using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class EditChannelRequestApiModel : IApiModel
{
    public Optional<string> Name { get; init; }

    public Optional<string> Description { get; init; }

    public Optional<Ulid> Owner { get; init; }
    
    public Optional<string> Icon { get; init; }
    
    public Optional<bool> Nsfw { get; init; }

    public Optional<bool> Archived { get; init; }

    public Optional<RemovedChannelField[]> Remove { get; init; }
}