namespace Rivoltante.Core;

public class UnicodeEmoji(string unicode) : IUnicodeEmoji
{
    public string Unicode { get; } = unicode;
}