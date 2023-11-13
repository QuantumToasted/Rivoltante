using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed record EditMessageApiModel(
    [property: JsonPropertyName("content")] Optional<string> Content,
    [property: JsonPropertyName("content")] Optional<MessageEmbedApiModel> Embeds) : ApiModel;