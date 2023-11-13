using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record EmojiApiModel(
    [property: JsonPropertyName("_id")] Ulid Id,
    [property: JsonPropertyName("parent")] EmojiParentApiModel Parent,
    [property: JsonPropertyName("creator_id")] Ulid CreatorId,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("animated")] bool Animated,
    [property: JsonPropertyName("nsfw")] bool Nsfw) : ApiModel;