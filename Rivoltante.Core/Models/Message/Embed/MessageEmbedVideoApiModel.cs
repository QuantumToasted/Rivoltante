using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageEmbedVideoApiModel(
    [property: JsonProperty("url")] string Url,
    [property: JsonProperty("width")] int Width,
    [property: JsonProperty("height")] int Height);