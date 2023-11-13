using System.Text.Json.Serialization;

namespace Rivoltante.Core;

// TODO: there are THREE different models with this same structure
public sealed record ServerRolePermissionsApiModel(
    [property: JsonPropertyName("a")] Permission A,
    [property: JsonPropertyName("b")] Permission D);