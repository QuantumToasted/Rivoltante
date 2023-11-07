using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageImageEmbedApiModel(
    string Type,
    [property: JsonProperty("url")] string Url,
    [property: JsonProperty("width")] int Width,
    [property: JsonProperty("height")] int Height,
    [property: JsonProperty("size")] string Size) : MessageEmbedApiModel(Type); // "Large", "Preview" TODO: Enum?