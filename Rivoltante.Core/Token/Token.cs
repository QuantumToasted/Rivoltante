namespace Rivoltante.Core;

public abstract record Token(string RawToken)
{
    public abstract string HeaderName { get; }
}