using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerRoleUpdateEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public required Ulid RoleId { get; init; }

    public required PartialServerRoleUpdateApiModel Data { get; init; }
    
    public required RemovedRoleField[] Clear { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ServerRoleUpdate;
}