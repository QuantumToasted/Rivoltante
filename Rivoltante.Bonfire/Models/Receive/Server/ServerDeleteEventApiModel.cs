using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerDeleteEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ServerDelete;
}