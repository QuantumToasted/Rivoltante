namespace Rivoltante.Core;

public sealed class UnicodeEmoji(string unicode) : IUnicodeEmoji
{
    public string Unicode { get; } = unicode;
}