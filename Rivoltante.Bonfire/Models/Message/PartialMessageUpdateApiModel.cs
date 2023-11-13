using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed record PartialMessageUpdateApiModel(
    //[property: JsonPropertyName("webhook")] Optional<MessageWebhookApiModel> Webhook,
    [property: JsonPropertyName("content")] Optional<string> Content,
    [property: JsonPropertyName("attachments")] Optional<AttachmentApiModel[]> Attachments,
    [property: JsonPropertyName("embeds")] Optional<MessageEmbedApiModel[]> Embeds,
    [property: JsonPropertyName("mentions")] Optional<Ulid[]> Mentions,
    [property: JsonPropertyName("replies")] Optional<Ulid[]> Replies,
    [property: JsonPropertyName("edited")] Optional<DateTimeOffset> Edited,
    //[property: JsonPropertyName("interactions")] Optional<MessageInteractionsApiModel> Interactions,
    [property: JsonPropertyName("masquerade")] Optional<MessageMasqueradeApiModel> Masquerade) : ApiModel;