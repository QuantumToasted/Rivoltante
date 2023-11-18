using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class UserApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required Ulid Id { get; init; }

    public required string Username { get; init; }

    public required string Discriminator { get; init; }

    public Optional<string> DisplayName { get; init; }

    public Optional<AttachmentApiModel> Avatar { get; init; }

    public Optional<UserRelationshipApiModel[]> Relations { get; init; }

    public Optional<UserBadge> Badges { get; init; }
    
    public Optional<UserStatusApiModel> Status { get; init; }

    public Optional<UserProfileApiModel> Profile { get; init; }

    public Optional<UserFlag> Flags { get; init; }

    public Optional<bool> Privileged { get; init; }

    public Optional<UserBotInformationApiModel> Bot { get; init; }

    public Optional<UserRelationshipStatus> Relationship { get; init; }

    public Optional<bool> Online { get; init; }
}