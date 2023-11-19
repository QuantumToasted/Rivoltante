using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelUpdateEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }
    
    public required PartialChannelUpdateApiModel Data { get; init; }
    
    public required RemovedChannelField[] Clear { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ChannelUpdate;
}