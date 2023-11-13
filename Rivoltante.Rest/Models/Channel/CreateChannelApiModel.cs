using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateChannelApiModel(
    [property: JsonPropertyName("type")] string Type, // "Text", "Voice"
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] Optional<string> Description,
    [property: JsonPropertyName("nsfw")] Optional<bool> Nsfw) : ApiModel;