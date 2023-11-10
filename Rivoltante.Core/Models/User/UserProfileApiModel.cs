using Newtonsoft.Json;

namespace Rivoltante.Core;

public record UserProfileApiModel(
    [property: JsonProperty("content")] Optional<string> Content,
    [property: JsonProperty("background")] Optional<AttachmentApiModel> Background) : ApiModel;