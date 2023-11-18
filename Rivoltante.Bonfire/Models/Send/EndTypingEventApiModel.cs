using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class EndTypingEventApiModel : ISendEventApiModel
{
    public required Ulid Channel { get; init; }

    public SendEventType Type => SendEventType.EndTyping;
}