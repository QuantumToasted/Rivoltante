using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateMessageApiModel(
    [property: JsonProperty("content")] Optional<string> Content,
    [property: JsonProperty("attachments")] Optional<string[]> Attachments,
    [property: JsonProperty("replies")] Optional<CreateMessageReplyApiModel[]> Replies,
    [property: JsonProperty("embeds")] Optional<CreateMessageEmbedApiModel[]> Embeds,
    [property: JsonProperty("masquerade")] Optional<MessageMasqueradeApiModel> Masquerade,
    [property: JsonProperty("interactions")] Optional<MessageInteractionsApiModel> Interactions) : ApiModel, IHeaderMetadata
{
    public IReadOnlyDictionary<string, string> Headers => new Dictionary<string, string> { ["Idempotency-Key"] = Ulid.FromGuid(Guid.NewGuid()) };
}