using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SearchChannelMessagesApiModel(
    [property: JsonProperty("query")] string Query,
    [property: JsonProperty("query")] Optional<int> Limit,
    [property: JsonProperty("query")] Optional<Ulid> Before,
    [property: JsonProperty("query")] Optional<Ulid> After,
    [property: JsonProperty("query")] Optional<MessageSortOrder> Sort,
    [property: JsonProperty("query")] Optional<bool> IncludeUsers) : ApiModel;