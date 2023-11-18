using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelUpdatedEventArgs(ChannelUpdateEventApiModel model)
    : EventArgs
{
    public Ulid ChannelId { get; } = model.Id;
    
    public PartialChannelUpdateApiModel Model { get; } = model.Data;
    
    public IReadOnlyList<RemovedChannelField> RemovedFields { get; } = model.Clear.ToList();
}