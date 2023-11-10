using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rivoltante.Core;

public record AttachmentApiModel(
    [property: JsonProperty("_id")] string Id,
    [property: JsonProperty("tag")] string Tag,
    [property: JsonProperty("filename")] string Filename,
    [property: JsonProperty("metadata")] JObject Metadata,
    [property: JsonProperty("content_type")] string ContentType,
    [property: JsonProperty("size")] long Size,
    [property: JsonProperty("deleted")] Optional<bool> Deleted,
    [property: JsonProperty("reported")] Optional<bool> Reported,
    [property: JsonProperty("message_id")] Optional<string> MessageId,
    [property: JsonProperty("user_id")] Optional<string> UserId,
    [property: JsonProperty("server_id")] Optional<string> ServerId,
    [property: JsonProperty("object_id")] Optional<string> ObjectId) : ApiModel;