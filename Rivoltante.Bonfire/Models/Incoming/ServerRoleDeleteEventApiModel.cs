using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ServerRoleDeleteEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("role_id")] Ulid RoleId) : IncomingEventApiModel(IncomingEventType.ServerRoleDelete);