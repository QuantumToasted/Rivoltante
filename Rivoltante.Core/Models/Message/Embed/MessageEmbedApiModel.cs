using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageEmbedApiModel(
    [property: JsonPropertyName("type")] EmbedType Type,
    [property: JsonPropertyName("url")] Optional<string> Url,
    [property: JsonPropertyName("original_url")] Optional<string> OriginalUrl,
    [property: JsonPropertyName("special")] Optional<MessageWebsiteEmbedSpecialApiModel> Special,
    [property: JsonPropertyName("title")] Optional<string> Title,
    [property: JsonPropertyName("description")] Optional<string> Description,
    [property: JsonPropertyName("image")] Optional<MessageEmbedImageApiModel> Image,
    [property: JsonPropertyName("video")] Optional<MessageEmbedVideoApiModel> Video,
    [property: JsonPropertyName("site_name")] Optional<string> SiteName,
    [property: JsonPropertyName("icon_url")] Optional<string> IconUrl,
    [property: JsonPropertyName("colour")] Optional<string> Color,
    [property: JsonPropertyName("width")] Optional<int> Width,
    [property: JsonPropertyName("height")] Optional<int> Height,
    [property: JsonPropertyName("media")] Optional<AttachmentApiModel> Media,
    [property: JsonPropertyName("size")] Optional<EmbedImageSize> Size) : ApiModel;