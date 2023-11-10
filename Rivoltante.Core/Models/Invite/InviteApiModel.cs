using Newtonsoft.Json;

namespace Rivoltante.Core;

public sealed record InviteApiModel(
    [property: JsonProperty("_id")] string Id,
    [property: JsonProperty("type")] InviteType Type,
    [property: JsonProperty("creator")] Ulid Creator,
    [property: JsonProperty("channel")] Ulid Channel,
    [property: JsonProperty("server")] Optional<Ulid> Server) : ApiModel;