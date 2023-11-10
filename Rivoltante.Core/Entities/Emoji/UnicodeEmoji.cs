namespace Rivoltante.Core.Emoji;

public class UnicodeEmoji(string unicode) : IUnicodeEmoji
{
    public string Unicode { get; } = unicode;
}