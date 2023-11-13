using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record AttachmentApiModel(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("tag")] string Tag,
    [property: JsonPropertyName("filename")] string Filename,
    [property: JsonPropertyName("metadata")] AttachmentMetadataApiModel Metadata,
    [property: JsonPropertyName("content_type")] string ContentType,
    [property: JsonPropertyName("size")] long Size,
    [property: JsonPropertyName("deleted")] Optional<bool> Deleted,
    [property: JsonPropertyName("reported")] Optional<bool> Reported,
    [property: JsonPropertyName("message_id")] Optional<string> MessageId,
    [property: JsonPropertyName("user_id")] Optional<string> UserId,
    [property: JsonPropertyName("server_id")] Optional<string> ServerId,
    [property: JsonPropertyName("object_id")] Optional<string> ObjectId) : ApiModel;