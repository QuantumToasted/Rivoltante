using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class BeginTypingEventApiModel : ISendEventApiModel
{
    public required Ulid Channel { get; init; }

    public SendEventType Type => SendEventType.BeginTyping;
}