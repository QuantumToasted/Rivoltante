using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record PermissionOverrideApiModel(
    [property: JsonPropertyName("a")] Permission A, // allowed
    [property: JsonPropertyName("d")] Permission D); // denied