using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageEmbedImageApiModel(
    [property: JsonProperty("url")] string Url,
    [property: JsonProperty("width")] int Width,
    [property: JsonProperty("height")] int Height,
    [property: JsonProperty("size")] string Size); // "Large", "Preview" TODO: Enum?