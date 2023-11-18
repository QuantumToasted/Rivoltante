using System.Diagnostics.CodeAnalysis;

namespace Rivoltante.Core;

public static partial class Ensure
{
    internal static class ThrowHelper
    {
        public static class ArgumentException
        {
            [DoesNotReturn]
            public static void IsNotNull<T>(string? name)
                => throw new System.ArgumentException($"Parameter {name ?? "provided"} ({typeof(T).Name}) must not be null.");
        
            [DoesNotReturn]
            public static void Is<TExpected>(Type? actualType, string? name)
                => throw new System.ArgumentException($"Parameter {name ?? "provided"} must be an instance of type ({typeof(TExpected).Name}), was {actualType?.Name ?? "null"}.");

            [DoesNotReturn]
            public static void That(string? name, bool isExpression)
                => throw new System.ArgumentException($"{(isExpression ? "Expression" : "Parameter")} {name ?? "provided"} must be true, was false.");
        }
    }
}