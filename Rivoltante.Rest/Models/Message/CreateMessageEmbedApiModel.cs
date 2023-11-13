using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateMessageEmbedApiModel(
    [property: JsonPropertyName("icon_url")] Optional<string> IconUrl,
    [property: JsonPropertyName("url")] Optional<string> Url,
    [property: JsonPropertyName("title")] Optional<string> Title,
    [property: JsonPropertyName("description")] Optional<string> Description,
    [property: JsonPropertyName("media")] Optional<string> Media,
    [property: JsonPropertyName("colour")] Optional<string> Color) : ApiModel;