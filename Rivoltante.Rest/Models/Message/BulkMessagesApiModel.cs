using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

// TODO: Formerly FetchMessageWithUsersApiModel - this model is returned internally even if users are not included for simplicity
public record BulkMessagesApiModel(
    [property: JsonPropertyName("messages")] MessageApiModel[] Messages,
    [property: JsonPropertyName("users")] UserApiModel[] Users,
    [property: JsonPropertyName("members")] Optional<MemberApiModel[]> Members) : ApiModel;