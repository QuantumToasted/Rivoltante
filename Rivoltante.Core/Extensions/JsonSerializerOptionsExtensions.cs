using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Rivoltante.Core;

public static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions WithRivoltanteDefaults(this JsonSerializerOptions options)
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        
        options.Converters.Add(new OptionalJsonConverter());
        options.Converters.Add(new UlidJsonConverter());
        options.Converters.Add(new JsonStringEnumConverter());

        options.TypeInfoResolver ??= new DefaultJsonTypeInfoResolver();
        options.TypeInfoResolver.WithAddedModifier(OptionalJsonTypeInfoResolverModifer.Instance);
        
        return options;
    }
}