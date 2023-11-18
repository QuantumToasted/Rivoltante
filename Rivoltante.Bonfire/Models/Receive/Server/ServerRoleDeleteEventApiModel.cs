using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerRoleDeleteEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public required Ulid RoleId { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ServerRoleDelete;
}