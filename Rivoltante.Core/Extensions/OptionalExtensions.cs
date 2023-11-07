namespace Rivoltante.Core;

public static class OptionalExtensions
{
    public static T? GetValueOrDefault<T>(this Optional<T> optional)
        => optional.HasValue ? optional.Value : default;
    
    public static T? GetValueOrNullable<T>(this Optional<T> optional) where T : struct
        => optional.HasValue ? optional.Value : new T?();

    public static T GetValueOrFallback<T>(this Optional<T> optional, T fallback)
        => optional.HasValue ? optional.Value : fallback;

    public static T GetValueOrFallback<T>(this Optional<T> optional, Func<T> fallbackFactory)
        => optional.HasValue ? optional.Value : fallbackFactory();
}