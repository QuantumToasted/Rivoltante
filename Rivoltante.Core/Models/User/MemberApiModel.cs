using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MemberApiModel(
    [property: JsonProperty("_id")] MemberIdApiModel Id,
    [property: JsonProperty("joined_at")] DateTimeOffset JoinedAt,
    [property: JsonProperty("nickname")] Optional<string> Nickname,
    [property: JsonProperty("avatar")] Optional<AttachmentApiModel> Avatar,
    [property: JsonProperty("roles")] Optional<Ulid[]> Roles,
    [property: JsonProperty("timeout")] Optional<DateTimeOffset> Timeout) : ApiModel;