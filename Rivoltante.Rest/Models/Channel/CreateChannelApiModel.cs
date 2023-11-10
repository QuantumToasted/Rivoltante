using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateChannelApiModel(
    [property: JsonProperty("type")] string Type, // "Text", "Voice"
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("description")] Optional<string> Description,
    [property: JsonProperty("nsfw")] Optional<bool> Nsfw) : ApiModel;