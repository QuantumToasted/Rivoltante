using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageWebsiteEmbedSpecialApiModel(
    [property: JsonProperty("type")] EmbedWebsiteSpecialType Type,
    [property: JsonProperty("id")] Optional<string> Id,
    [property: JsonProperty("timestamp")] Optional<string> Timestamp,
    [property: JsonProperty("content_type")] Optional<string> ContentType);