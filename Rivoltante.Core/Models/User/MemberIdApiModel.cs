using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MemberIdApiModel(
    [property: JsonProperty("server")] Ulid Server,
    [property: JsonProperty("user")] Ulid User) : ApiModel;