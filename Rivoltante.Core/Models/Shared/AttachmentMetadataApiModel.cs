using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record AttachmentMetadataApiModel(
    [property: JsonPropertyName("type")] AttachmentMetadataType Type,
    [property: JsonPropertyName("width")] Optional<int> Width,
    [property: JsonPropertyName("height")] Optional<int> Height) : ApiModel;