namespace Rivoltante.Core;

public interface ICustomEmoji : IEmoji
{
    Ulid Id { get; }

    string IEmoji.Value => Id.ToString();
    bool IEquatable<IEmoji>.Equals(IEmoji? other) => Id.Equals((other as ICustomEmoji)?.Id);
    int IComparable<IEmoji>.CompareTo(IEmoji? other) => Id.CompareTo((other as ICustomEmoji)?.Id);
}