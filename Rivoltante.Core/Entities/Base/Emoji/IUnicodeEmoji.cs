namespace Rivoltante.Core;

public interface IUnicodeEmoji : IEmoji
{
    string Unicode { get; }
    
    string IEmoji.Value => Unicode;
    bool IEquatable<IEmoji>.Equals(IEmoji? other) => Unicode.Equals((other as IUnicodeEmoji)?.Unicode);
    int IComparable<IEmoji>.CompareTo(IEmoji? other) => string.CompareOrdinal(Unicode, (other as IUnicodeEmoji)?.Unicode);
}