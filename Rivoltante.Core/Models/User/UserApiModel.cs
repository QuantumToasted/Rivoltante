using Newtonsoft.Json;

namespace Rivoltante.Core;

public sealed record UserApiModel(
    [property: JsonProperty("_id")] Ulid Id,
    [property: JsonProperty("username")] string Username,
    [property: JsonProperty("discriminator")] string Discriminator,
    [property: JsonProperty("display_name")] Optional<string> DisplayName,
    [property: JsonProperty("avatar")] Optional<AttachmentApiModel> Avatar,
    [property: JsonProperty("relations")] Optional<UserRelationshipApiModel[]> Relations,
    [property: JsonProperty("badges")] Optional<UserBadge> Badges,
    [property: JsonProperty("status")] Optional<UserStatusApiModel> Status,
    [property: JsonProperty("profile")] Optional<UserProfileApiModel> Profile,
    [property: JsonProperty("flags")] Optional<UserFlag> Flags,
    [property: JsonProperty("privileged")] bool Privileged,
    [property: JsonProperty("bot")] Optional<UserBotInformationApiModel> Bot,
    [property: JsonProperty("relationship")] Optional<UserRelationshipStatus> Relationship,
    [property: JsonProperty("online")] Optional<bool> Online) : ApiModel;