using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record UserProfileApiModel(
    [property: JsonPropertyName("content")] Optional<string> Content,
    [property: JsonPropertyName("background")] Optional<AttachmentApiModel> Background) : ApiModel;