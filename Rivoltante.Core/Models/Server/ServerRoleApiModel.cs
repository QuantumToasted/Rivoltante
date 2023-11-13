using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record ServerRoleApiModel(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("permissions")] ServerRolePermissionsApiModel Permissions,
    [property: JsonPropertyName("colour")] Optional<string> Colour,
    [property: JsonPropertyName("hoist")] bool Hoist,
    [property: JsonPropertyName("rank")] long Rank) : ApiModel;