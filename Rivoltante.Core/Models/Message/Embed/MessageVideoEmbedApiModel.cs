using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageVideoEmbedApiModel(
    string Type,
    [property: JsonProperty("wrl")] string Url,
    [property: JsonProperty("width")] int Width,
    [property: JsonProperty("height")] int Height) : MessageEmbedApiModel(Type);