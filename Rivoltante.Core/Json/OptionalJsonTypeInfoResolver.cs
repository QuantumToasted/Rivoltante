using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Rivoltante.Core;

public class OptionalJsonTypeInfoResolver : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var typeInfo = base.GetTypeInfo(type, options);
        
        foreach (var property in typeInfo.Properties)
        {
            if (!typeof(IOptional).IsAssignableFrom(property.PropertyType))
                continue;

            property.ShouldSerialize = (_, value) => value is IOptional { HasValue: true };
        }

        return typeInfo;
    }
    
}