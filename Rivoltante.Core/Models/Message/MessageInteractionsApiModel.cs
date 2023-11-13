using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageInteractionsApiModel(
    [property: JsonPropertyName("reactions")] Optional<string[]> Reactions,
    [property: JsonPropertyName("restrict_reactions")] bool RestrictReactions) : ApiModel;