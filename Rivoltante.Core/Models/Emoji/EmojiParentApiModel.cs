using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record EmojiParentApiModel(
    [property: JsonPropertyName("type")] EmojiParentType Type,
    [property: JsonPropertyName("id")] Optional<Ulid> Id) : ApiModel;