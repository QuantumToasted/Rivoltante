using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

// TODO: this has the same data as ServerApiModel. Find a way to merge?
public record ServerCreateEventApiModel(
    [property: JsonPropertyName("_id")] Ulid Id,
    [property: JsonPropertyName("owner")] Ulid Owner,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] Optional<string> Description,
    [property: JsonPropertyName("channels")] ChannelApiModel[] Channels,
    [property: JsonPropertyName("categories")] Optional<ServerChannelCategoryApiModel[]> Categories,
    [property: JsonPropertyName("system_messages")] Optional<ServerSystemMessagesApiModel> SystemMessages,
    [property: JsonPropertyName("roles")] Optional<Dictionary<Ulid, ServerRoleApiModel>> Roles,
    [property: JsonPropertyName("default_permissions")] Permission DefaultPermissions,
    [property: JsonPropertyName("icon")] Optional<AttachmentApiModel> Icon,
    [property: JsonPropertyName("banner")] Optional<AttachmentApiModel> Banner,
    [property: JsonPropertyName("flags")] Optional<ServerFlag> Flags,
    [property: JsonPropertyName("nsfw")] bool Nsfw,
    [property: JsonPropertyName("analytics")] bool Analytics,
    [property: JsonPropertyName("discoverable")] bool Discoverable) : IncomingEventApiModel(IncomingEventType.ServerCreate);