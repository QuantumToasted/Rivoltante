using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record PartialMemberUpdateApiModel(
    [property: JsonPropertyName("nickname")] Optional<string> Nickname,
    [property: JsonPropertyName("avatar")] Optional<AttachmentApiModel> Avatar,
    [property: JsonPropertyName("roles")] Optional<Ulid[]> Roles,
    [property: JsonPropertyName("timeout")] Optional<DateTimeOffset> Timeout) : ApiModel;