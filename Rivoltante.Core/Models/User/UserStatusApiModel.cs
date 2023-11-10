using Newtonsoft.Json;

namespace Rivoltante.Core;

public record UserStatusApiModel(
    [property: JsonProperty("avatar")] Optional<string> Text,
    [property: JsonProperty("avatar")] Optional<UserPresence> Presence) : ApiModel;