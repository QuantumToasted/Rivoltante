using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record ServerSystemMessagesApiModel(
    [property: JsonPropertyName("user_joined")] Optional<Ulid> UserJoined,
    [property: JsonPropertyName("user_left")] Optional<Ulid> UserLeft,
    [property: JsonPropertyName("user_kicked")] Optional<Ulid> UserKicked,
    [property: JsonPropertyName("user_banned")] Optional<Ulid> UserBanned) : ApiModel;