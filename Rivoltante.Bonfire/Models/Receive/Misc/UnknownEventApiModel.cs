namespace Rivoltante.Bonfire;

public sealed class UnknownEventApiModel : IReceiveEventApiModel
{
    public ReceiveEventType? Type => null;
}