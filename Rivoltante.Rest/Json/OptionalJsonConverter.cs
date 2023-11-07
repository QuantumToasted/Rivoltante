using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public class OptionalJsonConverter : JsonConverter<IOptional>
{
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
}