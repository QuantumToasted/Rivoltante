using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SetServerChannelDefaultPermissionsApiModel(
    [property: JsonProperty("permissions")] RolePermissionsApiModel Permissions) : ApiModel;