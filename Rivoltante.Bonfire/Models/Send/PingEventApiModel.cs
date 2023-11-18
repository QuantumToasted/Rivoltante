namespace Rivoltante.Bonfire;

public sealed class PingEventApiModel : ISendEventApiModel
{
    // Data is a timestamp
    public required long Data { get; init; }

    public SendEventType Type => SendEventType.Ping;
} 