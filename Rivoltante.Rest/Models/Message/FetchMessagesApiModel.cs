using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

// TODO: Formerly FetchMessageWithUsersApiModel - this model is returned internally even if users are not included for simplicity
public record FetchMessagesApiModel(
    [property: JsonProperty("messages")] MessageApiModel[] Messages,
    [property: JsonProperty("users")] UserApiModel[] Users,
    [property: JsonProperty("members")] Optional<MemberApiModel[]> Members) : ApiModel;