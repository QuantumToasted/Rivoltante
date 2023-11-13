using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageEmbedVideoApiModel(
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("width")] int Width,
    [property: JsonPropertyName("height")] int Height);