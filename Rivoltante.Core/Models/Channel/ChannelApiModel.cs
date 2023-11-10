using Newtonsoft.Json;

namespace Rivoltante.Core;

public sealed record ChannelApiModel(
    [property: JsonProperty("_id")] Ulid Id,
    [property: JsonProperty("channel_type")] ChannelType ChannelType,
    [property: JsonProperty("active")] Optional<bool> Active,
    [property: JsonProperty("recipients")] Optional<Ulid[]> Recipients,
    [property: JsonProperty("last_message_id")] Optional<Ulid> LastMessageId,
    [property: JsonProperty("name")] Optional<string> Name,
    [property: JsonProperty("owner")] Optional<Ulid> Owner,
    [property: JsonProperty("description")] Optional<string> Description,
    [property: JsonProperty("icon")] Optional<AttachmentApiModel> Icon,
    [property: JsonProperty("permissions")] Optional<Permission> Permissions,
    [property: JsonProperty("nsfw")] Optional<bool> Nsfw,
    [property: JsonProperty("user")] Optional<Ulid> User,
    [property: JsonProperty("server")] Optional<Ulid> Server,
    [property: JsonProperty("default_permissions")] Optional<PermissionOverrideApiModel> DefaultPermissions,
    [property: JsonProperty("role_permissions")] Optional<Dictionary<string, PermissionOverrideApiModel>> RolePermissions) : ApiModel;