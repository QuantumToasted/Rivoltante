using Newtonsoft.Json;

namespace Rivoltante.Core;

public record PermissionOverrideApiModel(
    [property: JsonProperty("a")] Permissions A, // allowed
    [property: JsonProperty("d")] Permissions D); // denied