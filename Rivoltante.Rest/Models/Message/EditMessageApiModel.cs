using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed record EditMessageApiModel(
    [property: JsonProperty("content")] Optional<string> Content,
    [property: JsonProperty("content")] Optional<MessageEmbedApiModel> Embeds) : ApiModel;