namespace Rivoltante.Core;

public sealed record BotToken(string RawToken) : Token(RawToken)
{
    public override string HeaderName => "X-Bot-Token";
}