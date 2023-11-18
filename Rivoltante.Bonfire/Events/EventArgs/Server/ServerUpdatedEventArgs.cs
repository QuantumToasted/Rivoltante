using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class ServerUpdatedEventArgs(Ulid serverId, PartialServerUpdateApiModel model, IEnumerable<RemovedServerField> removedFields) : EventArgs
{
    public Ulid ServerId { get; } = serverId;
    
    public PartialServerUpdateApiModel Model { get; } = model;
    
    public IReadOnlyList<RemovedServerField> RemovedFields { get; } = removedFields.ToList();
}