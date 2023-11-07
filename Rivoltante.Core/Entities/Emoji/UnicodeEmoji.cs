namespace Rivoltante.Core.Emoji;

public class UnicodeEmoji : IUnicodeEmoji
{
    public UnicodeEmoji(string unicode)
    {
        Unicode = unicode;
    }
    
    public string Unicode { get; }
}