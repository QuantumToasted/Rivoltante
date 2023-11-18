namespace Rivoltante.Core;

public interface IEmoji : IEquatable<IEmoji>, IComparable<IEmoji>
{
    string Value { get; }
}