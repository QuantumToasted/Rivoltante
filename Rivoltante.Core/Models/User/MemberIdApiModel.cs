using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MemberIdApiModel(
    [property: JsonPropertyName("server")] Ulid Server,
    [property: JsonPropertyName("user")] Ulid User) : ApiModel;