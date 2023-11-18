using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class NodeQueryApiModel : IApiModel
{
    public required string Revolt { get; init; }

    public required RevoltFeatureListApiModel Features { get; init; }

    public required string Ws { get; init; }
    
    public required string App { get; init; }
    
    public required string Vapid { get; init; }
    
    public required RevoltBuildInformationApiModel Build { get; init; }
}