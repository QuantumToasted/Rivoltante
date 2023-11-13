using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ServerRoleUpdateEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("role_id")] Ulid RoleId,
    [property: JsonPropertyName("data")] PartialServerRoleUpdateApiModel Data,
    [property: JsonPropertyName("clear")] RemovedRoleField[] Clear) : IncomingEventApiModel(IncomingEventType.ServerRoleUpdate);