using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageReplyApiModel(
    [property: JsonProperty("id")] string Id,
    [property: JsonProperty("mention")] bool Mention) : ApiModel;