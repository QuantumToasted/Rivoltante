using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public class OptionalJsonConverter : JsonConverter<IOptional>
{
    /*
    public override void WriteJson(JsonWriter writer, IOptional? value, JsonSerializer serializer)
    {
        if (value is not { HasValue: true })
            return;
        
        var optionalValue = value.Value;
        if (optionalValue is null)
        {
            writer.WriteNull();
        }
        else
        {
            serializer.Serialize(writer, optionalValue);
        }
    }

    public override IOptional ReadJson(JsonReader reader, Type objectType, IOptional? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return (IOptional) objectType.GetConstructors()[0].Invoke(new[] { serializer.Deserialize(reader, objectType.GenericTypeArguments[0]) });
    }
    */

    public override bool CanConvert(Type typeToConvert)
        => typeof(IOptional).IsAssignableFrom(typeToConvert);

    public override IOptional Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var constructor = typeToConvert.GetConstructors()[0];
        var value = JsonSerializer.Deserialize(ref reader, typeToConvert.GenericTypeArguments[0], options);
        return (IOptional)constructor.Invoke(new[] { value });
    }

    public override void Write(Utf8JsonWriter writer, IOptional? value, JsonSerializerOptions options)
    {
        if (value is not { HasValue: true })
            return;

        var optionalValue = value.Value;
        if (optionalValue is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, optionalValue, options);
        }
    }
}