using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerMemberUpdateEventApiModel : IReceiveEventApiModel
{
    public required MemberIdApiModel Id { get; init; }
    
    public required PartialServerMemberUpdateApiModel Data { get; init; }
    
    public required RemovedMemberField[] Clear { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ServerMemberUpdate;
}