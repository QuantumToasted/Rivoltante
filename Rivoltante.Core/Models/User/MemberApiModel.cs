using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MemberApiModel(
    [property: JsonPropertyName("_id")] MemberIdApiModel Id,
    [property: JsonPropertyName("joined_at")] DateTimeOffset JoinedAt,
    [property: JsonPropertyName("nickname")] Optional<string> Nickname,
    [property: JsonPropertyName("avatar")] Optional<AttachmentApiModel> Avatar,
    [property: JsonPropertyName("roles")] Optional<Ulid[]> Roles,
    [property: JsonPropertyName("timeout")] Optional<DateTimeOffset> Timeout) : ApiModel;