using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageWebsiteEmbedApiModel(
    string Type,
    [property: JsonProperty("url")] Optional<string> Url,
    [property: JsonProperty("original_url")] Optional<string> OriginalUrl,
    [property: JsonProperty("special")] Optional<MessageWebsiteEmbedSpecialApiModel> Special,
    [property: JsonProperty("title")] Optional<string> Title,
    [property: JsonProperty("description")] Optional<string> Description,
    [property: JsonProperty("image")] Optional<MessageEmbedImageApiModel> Image,
    [property: JsonProperty("video")] Optional<MessageEmbedVideoApiModel> Video,
    [property: JsonProperty("site_name")] Optional<string> SiteName,
    [property: JsonProperty("icon_url")] Optional<string> IconUrl,
    [property: JsonProperty("colour")] Optional<string> Color) : MessageEmbedApiModel(Type);