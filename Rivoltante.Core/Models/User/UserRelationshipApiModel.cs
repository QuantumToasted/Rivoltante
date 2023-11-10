using Newtonsoft.Json;

namespace Rivoltante.Core;

public record UserRelationshipApiModel(
    [property: JsonProperty("_id")] Ulid Id,
    [property: JsonProperty("status")] UserRelationshipStatus Status) : ApiModel;