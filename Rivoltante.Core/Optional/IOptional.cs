namespace Rivoltante.Core;

public interface IOptional
{
    bool HasValue { get; }
    object? Value { get; }
}

public interface IOptional<T> : IOptional, 
    IEquatable<IOptional<T>>, 
    IEquatable<T>,
    IComparable<IOptional<T>>,
    IComparable<T>
{
    new T Value { get; }
}