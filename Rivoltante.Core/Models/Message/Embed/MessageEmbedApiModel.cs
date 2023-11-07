using Newtonsoft.Json;

namespace Rivoltante.Core;

public abstract record MessageEmbedApiModel(
    [property: JsonProperty("type")] string Type) : ApiModel;