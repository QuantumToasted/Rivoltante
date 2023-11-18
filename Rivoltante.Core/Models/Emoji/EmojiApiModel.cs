using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public class EmojiApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required Ulid Id { get; init; }
    
    public required EmojiParentApiModel Parent { get; init; }

    public required Ulid CreatorId { get; init; }

    public required string Name { get; init; }

    public Optional<bool> Animated { get; init; }

    public Optional<bool> Nsfw { get; init; }
}