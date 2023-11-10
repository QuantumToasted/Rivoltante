using Newtonsoft.Json;

namespace Rivoltante.Core;

public record PermissionOverrideApiModel(
    [property: JsonProperty("a")] Permission A, // allowed
    [property: JsonProperty("d")] Permission D); // denied