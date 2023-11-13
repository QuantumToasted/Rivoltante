using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record RolePermissionsApiModel(
    [property: JsonPropertyName("allow")] Permission Allow,
    [property: JsonPropertyName("deny")] Permission Deny) : ApiModel;