using System.Text.Json.Serialization.Metadata;

namespace Rivoltante.Core;

public static class OptionalJsonTypeInfoResolverModifer
{
    public static readonly Action<JsonTypeInfo> Instance = typeInfo =>
    {
        foreach (var property in typeInfo.Properties)
        {
            if (!typeof(IOptional).IsAssignableFrom(property.PropertyType))
                continue;

            property.ShouldSerialize = (_, value) => value is IOptional { HasValue: true };
        }
    };
}