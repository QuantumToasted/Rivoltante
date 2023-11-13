using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record ServerChannelCategoryApiModel(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("channels")] Ulid[] Channels) : ApiModel;