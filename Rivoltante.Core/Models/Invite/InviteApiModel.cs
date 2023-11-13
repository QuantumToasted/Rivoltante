using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed record InviteApiModel(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("type")] InviteType Type,
    [property: JsonPropertyName("creator")] Ulid Creator,
    [property: JsonPropertyName("channel")] Ulid Channel,
    [property: JsonPropertyName("server")] Optional<Ulid> Server) : ApiModel;