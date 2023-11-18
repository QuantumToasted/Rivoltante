namespace Rivoltante.Core;

public record SessionToken(string RawToken) : Token(RawToken)
{
    public override string HeaderName => "X-Session-Token";
}