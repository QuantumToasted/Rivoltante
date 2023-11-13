using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record PartialUserUpdateApiModel(
    [property: JsonPropertyName("username")] Optional<string> Username,
    [property: JsonPropertyName("discriminator")] Optional<string> Discriminator,
    [property: JsonPropertyName("display_name")] Optional<string> DisplayName,
    [property: JsonPropertyName("avatar")] Optional<AttachmentApiModel> Avatar,
    [property: JsonPropertyName("relations")] Optional<UserRelationshipApiModel[]> Relations,
    [property: JsonPropertyName("badges")] Optional<UserBadge> Badges,
    [property: JsonPropertyName("status")] Optional<UserStatusApiModel> Status,
    [property: JsonPropertyName("profile")] Optional<UserProfileApiModel> Profile,
    [property: JsonPropertyName("flags")] Optional<UserFlag> Flags,
    [property: JsonPropertyName("privileged")] Optional<bool> Privileged,
    [property: JsonPropertyName("bot")] Optional<UserBotInformationApiModel> Bot,
    [property: JsonPropertyName("relationship")] Optional<UserRelationshipStatus> Relationship,
    [property: JsonPropertyName("online")] Optional<bool> Online) : ApiModel;