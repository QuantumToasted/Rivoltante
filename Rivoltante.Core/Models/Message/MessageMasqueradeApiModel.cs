using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageMasqueradeApiModel(
    [property: JsonPropertyName("name")] Optional<string> Name,
    [property: JsonPropertyName("avatar")] Optional<string> Avatar,
    [property: JsonPropertyName("colour")] Optional<string> Color) : ApiModel;