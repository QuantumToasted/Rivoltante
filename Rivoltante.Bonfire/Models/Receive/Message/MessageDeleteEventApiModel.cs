using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageDeleteEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public required Ulid Channel { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.MessageDelete;
}