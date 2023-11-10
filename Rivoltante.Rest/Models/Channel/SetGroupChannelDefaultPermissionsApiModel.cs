using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SetGroupChannelDefaultPermissionsApiModel(
    [property: JsonProperty("permissions")] Permission Permissions) : ApiModel;