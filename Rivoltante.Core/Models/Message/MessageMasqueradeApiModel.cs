using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageMasqueradeApiModel(
    [property: JsonProperty("name")] Optional<string> Name,
    [property: JsonProperty("avatar")] Optional<string> Avatar,
    [property: JsonProperty("colour")] Optional<string> Color) : ApiModel;