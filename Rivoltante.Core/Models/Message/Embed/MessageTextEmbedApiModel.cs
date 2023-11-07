using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageTextEmbedApiModel(
    string Type,
    [property: JsonProperty("icon_url")] Optional<string> IconUrl,
    [property: JsonProperty("url")] Optional<string> Url,
    [property: JsonProperty("title")] Optional<string> Title,
    [property: JsonProperty("description")] Optional<string> Description,
    [property: JsonProperty("media")] Optional<string> Media,
    [property: JsonProperty("colour")] Optional<string> Color) : MessageEmbedApiModel(Type);