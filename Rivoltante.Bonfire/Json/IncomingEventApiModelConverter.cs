using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rivoltante.Bonfire;

public class IncomingEventApiModelConverter : JsonConverter<IncomingEventApiModel>
{
    public override IncomingEventApiModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, IncomingEventApiModel value, JsonSerializerOptions options)
        => throw new NotSupportedException();
}