using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SetChannelRolePermissionsApiModel(
    [property: JsonPropertyName("permissions")] RolePermissionsApiModel Permissions) : ApiModel;