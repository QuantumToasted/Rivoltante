using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerMemberUpdatedEventArgs(Ulid serverId, Ulid memberId, PartialServerMemberUpdateApiModel model, IEnumerable<RemovedMemberField> removedFields) 
    : EventArgs
{
    public Ulid ServerId { get; } = serverId;
    
    public Ulid MemberId { get; } = memberId;
    
    public PartialServerMemberUpdateApiModel Model { get; } = model;
    
    public IReadOnlyList<RemovedMemberField> RemovedFields { get; } = removedFields.ToList();
}