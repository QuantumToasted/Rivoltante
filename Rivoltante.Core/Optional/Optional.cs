namespace Rivoltante.Core;

public readonly struct Optional<T> : IOptional<T>
{
    private readonly T _value;

    public Optional(T value)
    {
        _value = value;
        HasValue = true;
    }

    public bool HasValue { get; } = false;

    public T Value => HasValue ? _value : throw new InvalidOperationException();

    public bool Equals(IOptional<T>? other)
         => other is not null && ((!HasValue && !other.HasValue) || (HasValue == other.HasValue && Equals(Value, other.Value)));

    public bool Equals(T? other)
        => HasValue && Equals(_value, other);

    public int CompareTo(IOptional<T>? other)
    {
        if (other is null)
            return int.MinValue; // TODO: return a more concise value for `other is null`?

        var compareValue = HasValue.CompareTo(other.HasValue);
        return compareValue != 0
            ? compareValue
            : CompareTo(other.Value);
    }

    public int CompareTo(T? other)
        => HasValue ? Comparer<T>.Default.Compare(Value, other) : -1;

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            IOptional<T> optional => Equals(optional),
            T value => Equals(value),
            _ => false
        };
    }

    public override int GetHashCode()
        => HasValue ? Value?.GetHashCode() ?? 0 : -1;

    public override string ToString()
        => HasValue ? Value?.ToString() ?? "{{null}}" : "{{no value}}";

    public static Optional<T> None => default;
    
    public static Optional<T> FromNullable(T? value)
        => value is not null ? value : None;

    public static Optional<T1> FromNullable<T1>(T1? value) where T1 : struct
        => value.HasValue ? new Optional<T1>(value.Value) : Optional<T1>.None;

    public static Optional<TNew> Convert<TOld, TNew>(Optional<TOld> optional, Converter<TOld, TNew> converter)
        => optional is { HasValue: true, Value: not null } ? converter(optional.Value) : Optional<TNew>.None;

    public static TNew? ConvertOrDefault<TOld, TNew>(Optional<TOld> optional, Converter<TOld, TNew> converter)
        => optional.HasValue ? converter(optional.Value) : default;
    
    public static TNew ConvertOrFallback<TOld, TNew>(Optional<TOld> optional, Converter<TOld, TNew> converter, TNew fallback)
        => optional.HasValue ? converter(optional.Value) : fallback;

    public static Optional<T> Conditional(T value, Func<T, bool> condition)
        => condition(value) ? value : None;

    public static bool operator ==(Optional<T> l, Optional<T> r)
        => l.Equals(r);

    public static bool operator !=(Optional<T> l, Optional<T> r)
        => !l.Equals(r);

    public static bool operator ==(Optional<T> l, T r)
        => l.Equals(r);

    public static bool operator !=(Optional<T> l, T r)
        => !l.Equals(r);

    public static implicit operator Optional<T>(T value)
        => new(value);

    object? IOptional.Value => Value;
}