using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageReplyApiModel(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("mention")] bool Mention) : ApiModel;