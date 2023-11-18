using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class RevoltFeatureApiModel : IApiModel
{
    public required bool Enabled { get; init; }

    public Optional<string> Key { get; init; }
    
    public Optional<string> Url { get; init; }
    
    public Optional<string> Ws { get; init; }
}