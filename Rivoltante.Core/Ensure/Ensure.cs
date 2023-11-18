using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Rivoltante.Core;

public static partial class Ensure
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotNull<T>([NotNull] T? value, [CallerArgumentExpression(nameof(value))] string? name = null)
        where T : class
    {
        if (value is not null)
            return;

        ThrowHelper.ArgumentException.IsNotNull<T>(name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TExpected Is<TExpected>(object? value, [CallerArgumentExpression(nameof(value))] string? name = null)
    {
        if (value is TExpected expected)
            return expected;
        
        ThrowHelper.ArgumentException.Is<TExpected>(value?.GetType(), name);
        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void That(bool value, [CallerArgumentExpression(nameof(value))] string? name = null)
    {
        if (value)
            return;
        
        ThrowHelper.ArgumentException.That(name, false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void That(Func<bool> expr, [CallerArgumentExpression(nameof(expr))] string? name = null)
    {
        Ensure.NotNull(expr);

        if (expr.Invoke())
            return;
        
        ThrowHelper.ArgumentException.That(name, true);
    }
}