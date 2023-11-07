using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageInteractionsApiModel(
    [property: JsonProperty("reactions")] Optional<string[]> Reactions,
    [property: JsonProperty("restrict_reactions")] bool RestrictReactions) : ApiModel;