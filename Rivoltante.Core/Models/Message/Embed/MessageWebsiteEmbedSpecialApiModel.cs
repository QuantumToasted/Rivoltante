using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageWebsiteEmbedSpecialApiModel(
    [property: JsonPropertyName("type")] EmbedWebsiteSpecialType Type,
    [property: JsonPropertyName("id")] Optional<string> Id,
    [property: JsonPropertyName("timestamp")] Optional<string> Timestamp,
    [property: JsonPropertyName("content_type")] Optional<string> ContentType);