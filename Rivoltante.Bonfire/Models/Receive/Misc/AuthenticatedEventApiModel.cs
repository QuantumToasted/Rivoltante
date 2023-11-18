namespace Rivoltante.Bonfire;

public sealed class AuthenticatedEventApiModel : IReceiveEventApiModel
{
    public ReceiveEventType? Type => ReceiveEventType.Authenticated;
}