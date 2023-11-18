using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageAppendEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public required Ulid Channel { get; init; }

    public required PartialMessageUpdateApiModel Append { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.MessageAppend;
}