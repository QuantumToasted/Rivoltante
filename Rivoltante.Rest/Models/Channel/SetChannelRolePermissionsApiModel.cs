using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SetChannelRolePermissionsApiModel(
    [property: JsonProperty("permissions")] RolePermissionsApiModel Permissions) : ApiModel;