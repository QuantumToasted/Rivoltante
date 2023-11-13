using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record ServerApiModel(
    [property: JsonPropertyName("_id")] Ulid Id,
    [property: JsonPropertyName("owner")] Ulid Owner,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] Optional<string> Description,
    [property: JsonPropertyName("channels")] Ulid[] Channels, // TODO: channel API models when getting full server info
    [property: JsonPropertyName("categories")] Optional<ServerChannelCategoryApiModel[]> Categories,
    [property: JsonPropertyName("system_messages")] Optional<ServerSystemMessagesApiModel> SystemMessages,
    [property: JsonPropertyName("roles")] Optional<Dictionary<Ulid, ServerRoleApiModel>> Roles,
    [property: JsonPropertyName("default_permissions")] Permission DefaultPermissions,
    [property: JsonPropertyName("icon")] Optional<AttachmentApiModel> Icon,
    [property: JsonPropertyName("banner")] Optional<AttachmentApiModel> Banner,
    [property: JsonPropertyName("flags")] Optional<ServerFlag> Flags,
    [property: JsonPropertyName("nsfw")] bool Nsfw,
    [property: JsonPropertyName("analytics")] bool Analytics,
    [property: JsonPropertyName("discoverable")] bool Discoverable) : ApiModel;