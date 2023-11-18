namespace Rivoltante.Core;

public readonly partial struct Ulid : IEquatable<Ulid>,
    IEquatable<string>,
    IComparable<Ulid>,
    IComparable<string>,
    IComparable
{
    public override int GetHashCode()
    {
        const int seed = -67205002;
        const int aggregateValue = 1587296083;

        var value = seed;

        for (var i = 0; i < RawValue.Length; i++)
        {
            unchecked
            {
                value = value * aggregateValue + RawValue[i];
            }
        }

        return value;
    }

    public bool Equals(Ulid other)
        => RawValue.SequenceEqual(other.RawValue);

    public bool Equals(string? other)
        => ToString().Equals(other);

    public int CompareTo(Ulid other)
        => CompareTo(other.ToString());

    public int CompareTo(string? other)
        => string.CompareOrdinal(ToString(), other);

    public int CompareTo(object? obj)
    {
        return obj switch
        {
            Ulid ulid => CompareTo(ulid),
            string s => CompareTo(s),
            _ => -1
        };
    }
    
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            Ulid ulid => Equals(ulid),
            string s => Equals(s),
            _ => false
        };
    }
}