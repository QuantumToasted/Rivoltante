using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageEmbedImageApiModel(
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("width")] int Width,
    [property: JsonPropertyName("height")] int Height,
    [property: JsonPropertyName("size")] EmbedImageSize Size);