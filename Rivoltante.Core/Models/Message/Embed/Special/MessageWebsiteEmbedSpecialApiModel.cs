using Newtonsoft.Json;

namespace Rivoltante.Core;

public abstract record MessageWebsiteEmbedSpecialApiModel(
    [property: JsonProperty("type")] string Type);