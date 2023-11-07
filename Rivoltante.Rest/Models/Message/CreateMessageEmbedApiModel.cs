using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateMessageEmbedApiModel(
    [property: JsonProperty("icon_url")] Optional<string> IconUrl,
    [property: JsonProperty("url")] Optional<string> Url,
    [property: JsonProperty("title")] Optional<string> Title,
    [property: JsonProperty("description")] Optional<string> Description,
    [property: JsonProperty("media")] Optional<string> Media,
    [property: JsonProperty("colour")] Optional<string> Color) : ApiModel;