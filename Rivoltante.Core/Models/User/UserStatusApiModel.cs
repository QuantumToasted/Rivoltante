using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record UserStatusApiModel(
    [property: JsonPropertyName("avatar")] Optional<string> Text,
    [property: JsonPropertyName("avatar")] Optional<UserPresence> Presence) : ApiModel;