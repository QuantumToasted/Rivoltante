using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed record UserApiModel(
    [property: JsonPropertyName("_id")] Ulid Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("discriminator")] string Discriminator,
    [property: JsonPropertyName("display_name")] Optional<string> DisplayName,
    [property: JsonPropertyName("avatar")] Optional<AttachmentApiModel> Avatar,
    [property: JsonPropertyName("relations")] Optional<UserRelationshipApiModel[]> Relations,
    [property: JsonPropertyName("badges")] Optional<UserBadge> Badges,
    [property: JsonPropertyName("status")] Optional<UserStatusApiModel> Status,
    [property: JsonPropertyName("profile")] Optional<UserProfileApiModel> Profile,
    [property: JsonPropertyName("flags")] Optional<UserFlag> Flags,
    [property: JsonPropertyName("privileged")] bool Privileged,
    [property: JsonPropertyName("bot")] Optional<UserBotInformationApiModel> Bot,
    [property: JsonPropertyName("relationship")] Optional<UserRelationshipStatus> Relationship,
    [property: JsonPropertyName("online")] Optional<bool> Online) : ApiModel;