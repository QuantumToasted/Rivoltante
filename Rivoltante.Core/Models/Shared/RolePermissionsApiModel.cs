using Newtonsoft.Json;

namespace Rivoltante.Core;

public record RolePermissionsApiModel(
    [property: JsonProperty("allow")] Permission Allow,
    [property: JsonProperty("deny")] Permission Deny) : ApiModel;