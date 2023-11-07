using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateMessageReplyApiModel(
    [property: JsonProperty("id")] string Id,
    [property: JsonProperty("mention")] bool Mention) : ApiModel;