using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageApiModel(
    [property: JsonProperty("_id")] Ulid Id,
    [property: JsonProperty("nonce")] Optional<string> Nonce,
    [property: JsonProperty("channel")] Ulid Channel,
    [property: JsonProperty("author")] Ulid Author,
    [property: JsonProperty("webhook")] Optional<MessageWebhookApiModel> Webhook,
    [property: JsonProperty("content")] Optional<string> Content,
    //[property: JsonProperty("system")] TODO: system property
    [property: JsonProperty("attachments")] Optional<AttachmentApiModel[]> Attachments,
    [property: JsonProperty("edited")] Optional<DateTimeOffset> Edited,
    [property: JsonProperty("embeds")] Optional<MessageEmbedApiModel[]> Embeds,
    [property: JsonProperty("mentions")] Optional<Ulid[]> Mentions,
    [property: JsonProperty("replies")] Optional<Ulid[]> Replies,
    [property: JsonProperty("reactions")] Optional<Dictionary<string, Ulid[]>> Reactions,
    [property: JsonProperty("interactions")] Optional<MessageInteractionsApiModel> Interactions,
    [property: JsonProperty("masquerade")] Optional<MessageMasqueradeApiModel> Masquerade) : ApiModel;