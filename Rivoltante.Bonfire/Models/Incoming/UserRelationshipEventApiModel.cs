using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record UserRelationshipEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("user")] UserApiModel User,
    [property: JsonPropertyName("status")] UserRelationshipStatus Status) : IncomingEventApiModel(IncomingEventType.UserRelationship);