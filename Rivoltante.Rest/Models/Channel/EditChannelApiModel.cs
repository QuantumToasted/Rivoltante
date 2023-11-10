using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed record EditChannelApiModel(
    [property: JsonProperty("name")] Optional<string> Name,
    [property: JsonProperty("description")] Optional<string> Description,
    [property: JsonProperty("owner")] Optional<Ulid> Owner,
    [property: JsonProperty("icon")] Optional<string> Icon,
    [property: JsonProperty("nsfw")] Optional<bool> Nsfw,
    [property: JsonProperty("archived")] Optional<bool> Archived,
    [property: JsonProperty("remove")] Optional<RemoveChannelField[]> Remove) : ApiModel;