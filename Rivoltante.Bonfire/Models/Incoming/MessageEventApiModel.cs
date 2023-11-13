using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

// TODO: this copies MessageApiModel - can they be merged somehow?
public record MessageEventApiModel(
    [property: JsonPropertyName("_id")] Ulid Id,
    [property: JsonPropertyName("nonce")] Optional<string> Nonce,
    [property: JsonPropertyName("channel")] Ulid Channel,
    [property: JsonPropertyName("author")] Ulid Author,
    [property: JsonPropertyName("webhook")] Optional<MessageWebhookApiModel> Webhook,
    [property: JsonPropertyName("content")] Optional<string> Content,
    //[property: JsonPropertyName("system")] TODO: system property
    [property: JsonPropertyName("attachments")] Optional<AttachmentApiModel[]> Attachments,
    [property: JsonPropertyName("edited")] Optional<DateTimeOffset> Edited,
    [property: JsonPropertyName("embeds")] Optional<MessageEmbedApiModel[]> Embeds,
    [property: JsonPropertyName("mentions")] Optional<Ulid[]> Mentions,
    [property: JsonPropertyName("replies")] Optional<Ulid[]> Replies,
    [property: JsonPropertyName("reactions")] Optional<Dictionary<string, Ulid[]>> Reactions,
    [property: JsonPropertyName("interactions")] Optional<MessageInteractionsApiModel> Interactions,
    [property: JsonPropertyName("masquerade")] Optional<MessageMasqueradeApiModel> Masquerade) : IncomingEventApiModel(IncomingEventType.Message);