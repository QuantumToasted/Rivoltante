using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageApiModel(
    [property: JsonProperty("_id")] string Id,
    [property: JsonProperty("nonce")] Optional<string> Nonce,
    [property: JsonProperty("channel")] string Channel,
    [property: JsonProperty("author")] string Author,
    [property: JsonProperty("webhook")] Optional<MessageWebhookApiModel> Webhook,
    [property: JsonProperty("content")] Optional<string> Content,
    //[property: JsonProperty("system")] TODO: system property
    [property: JsonProperty("attachments")] Optional<MessageAttachmentApiModel[]> Attachments,
    [property: JsonProperty("edited")] Optional<DateTimeOffset> Edited,
    [property: JsonProperty("embeds")] Optional<MessageEmbedApiModel[]> Embeds,
    [property: JsonProperty("mentions")] Optional<string[]> Mentions,
    [property: JsonProperty("replies")] Optional<string[]> Replies,
    [property: JsonProperty("reactions")] Optional<Dictionary<string, string[]>> Reactions,
    [property: JsonProperty("interactions")] Optional<MessageInteractionsApiModel> Interactions,
    [property: JsonProperty("masquerade")] Optional<MessageMasqueradeApiModel> Masquerade) : ApiModel;