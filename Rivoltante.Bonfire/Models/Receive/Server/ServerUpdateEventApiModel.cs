using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerUpdateEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }
    
    public required PartialServerUpdateApiModel Data { get; init; }
    
    public required RemovedServerField[] Clear { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ServerUpdate;
}