namespace Rivoltante.Bonfire;

public sealed class AuthenticateEventApiModel : ISendEventApiModel
{
    public required string Token { get; init; }

    public SendEventType Type => SendEventType.Authenticate;
}