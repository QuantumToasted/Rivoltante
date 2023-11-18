using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class ServerDeleteEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ServerDelete;
}