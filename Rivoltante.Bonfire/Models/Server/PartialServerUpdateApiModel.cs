using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record PartialServerUpdateApiModel(
    [property: JsonPropertyName("owner")] Optional<Ulid> Owner,
    [property: JsonPropertyName("name")] Optional<string> Name,
    [property: JsonPropertyName("description")] Optional<string> Description,
    //[property: JsonPropertyName("categories")] Optional<ServerChannelCategoryApiModel[]> Categories,
    [property: JsonPropertyName("system_messages")] Optional<ServerSystemMessagesApiModel> SystemMessages,
    //[property: JsonPropertyName("roles")] Optional<Dictionary<Ulid, ServerRoleApiModel>> Roles,
    [property: JsonPropertyName("default_permissions")] Optional<Permission> DefaultPermissions,
    [property: JsonPropertyName("icon")] Optional<AttachmentApiModel> Icon,
    [property: JsonPropertyName("banner")] Optional<AttachmentApiModel> Banner,
    [property: JsonPropertyName("flags")] Optional<ServerFlag> Flags,
    [property: JsonPropertyName("nsfw")] Optional<bool> Nsfw,
    [property: JsonPropertyName("analytics")] Optional<bool> Analytics,
    [property: JsonPropertyName("discoverable")] Optional<bool> Discoverable) : ApiModel;