using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SetGroupChannelDefaultPermissionsApiModel(
    [property: JsonPropertyName("permissions")] Permission Permissions) : ApiModel;