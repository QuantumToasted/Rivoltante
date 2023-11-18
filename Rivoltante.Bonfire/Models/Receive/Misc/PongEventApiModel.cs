namespace Rivoltante.Bonfire;

public sealed class PongEventApiModel : IReceiveEventApiModel
{
    public long Data { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.Pong;
}