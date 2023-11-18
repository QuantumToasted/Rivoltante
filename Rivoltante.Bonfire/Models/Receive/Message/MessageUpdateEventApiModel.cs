using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class MessageUpdateEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public required Ulid Channel { get; init; }

    public required PartialMessageUpdateApiModel Data { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.MessageUpdate;
}