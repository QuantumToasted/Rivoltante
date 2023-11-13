using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record UserRelationshipApiModel(
    [property: JsonPropertyName("_id")] Ulid Id,
    [property: JsonPropertyName("status")] UserRelationshipStatus Status) : ApiModel;