using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SetServerChannelDefaultPermissionsApiModel(
    [property: JsonPropertyName("permissions")] RolePermissionsApiModel Permissions) : ApiModel;