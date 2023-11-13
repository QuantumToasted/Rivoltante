using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

// TODO: this model is identical to ChannelApiModel. Find a way to merge?
public record ChannelCreateEventApiModel(
    [property: JsonPropertyName("_id")] Ulid Id,
    [property: JsonPropertyName("channel_type")] ChannelType ChannelType,
    [property: JsonPropertyName("active")] Optional<bool> Active,
    [property: JsonPropertyName("recipients")] Optional<Ulid[]> Recipients,
    [property: JsonPropertyName("last_message_id")] Optional<Ulid> LastMessageId,
    [property: JsonPropertyName("name")] Optional<string> Name,
    [property: JsonPropertyName("owner")] Optional<Ulid> Owner,
    [property: JsonPropertyName("description")] Optional<string> Description,
    [property: JsonPropertyName("icon")] Optional<AttachmentApiModel> Icon,
    [property: JsonPropertyName("permissions")] Optional<Permission> Permissions,
    [property: JsonPropertyName("nsfw")] Optional<bool> Nsfw,
    [property: JsonPropertyName("user")] Optional<Ulid> User,
    [property: JsonPropertyName("server")] Optional<Ulid> Server,
    [property: JsonPropertyName("default_permissions")] Optional<PermissionOverrideApiModel> DefaultPermissions,
    [property: JsonPropertyName("role_permissions")] Optional<Dictionary<Ulid, PermissionOverrideApiModel>> RolePermissions) 
    : IncomingEventApiModel(IncomingEventType.ChannelCreate);