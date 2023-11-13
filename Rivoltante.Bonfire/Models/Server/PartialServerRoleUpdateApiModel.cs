using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record PartialServerRoleUpdateApiModel(
    [property: JsonPropertyName("name")] Optional<string> Name,
    [property: JsonPropertyName("permissions")] Optional<ServerRolePermissionsApiModel> Permissions,
    [property: JsonPropertyName("colour")] Optional<string> Colour,
    [property: JsonPropertyName("hoist")] Optional<bool> Hoist,
    [property: JsonPropertyName("rank")] Optional<long> Rank) : ApiModel;