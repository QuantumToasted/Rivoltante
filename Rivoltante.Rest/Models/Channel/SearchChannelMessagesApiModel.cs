using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record SearchChannelMessagesApiModel(
    [property: JsonPropertyName("query")] string Query,
    [property: JsonPropertyName("query")] Optional<int> Limit,
    [property: JsonPropertyName("query")] Optional<Ulid> Before,
    [property: JsonPropertyName("query")] Optional<Ulid> After,
    [property: JsonPropertyName("query")] Optional<MessageSortOrder> Sort,
    [property: JsonPropertyName("query")] Optional<bool> IncludeUsers) : ApiModel;