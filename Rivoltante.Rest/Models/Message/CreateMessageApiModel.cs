using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record CreateMessageApiModel(
    [property: JsonPropertyName("content")] Optional<string> Content,
    [property: JsonPropertyName("attachments")] Optional<string[]> Attachments,
    [property: JsonPropertyName("replies")] Optional<CreateMessageReplyApiModel[]> Replies,
    [property: JsonPropertyName("embeds")] Optional<CreateMessageEmbedApiModel[]> Embeds,
    [property: JsonPropertyName("masquerade")] Optional<MessageMasqueradeApiModel> Masquerade,
    [property: JsonPropertyName("interactions")] Optional<MessageInteractionsApiModel> Interactions) : ApiModel, IHeaderMetadata
{
    public IReadOnlyDictionary<string, string> Headers => new Dictionary<string, string> { ["Idempotency-Key"] = Ulid.FromGuid(Guid.NewGuid()) };
}