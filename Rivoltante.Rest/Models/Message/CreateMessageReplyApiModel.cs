using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateMessageReplyApiModel(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("mention")] bool Mention) : ApiModel;