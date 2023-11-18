using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class OptionalJsonConverter : JsonConverter<IOptional>
{
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