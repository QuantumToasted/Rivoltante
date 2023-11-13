using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record PartialMessageAppendApiModel(
    [property: JsonPropertyName("embeds")] Optional<MessageEmbedApiModel[]> Embeds) : ApiModel;