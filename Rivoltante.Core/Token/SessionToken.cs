namespace Rivoltante.Core;

public sealed record SessionToken(string RawToken) : Token(RawToken)
{
    public override string HeaderName => "X-Session-Token";
}