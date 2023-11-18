using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public class MessageApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required Ulid Id { get; init; }

    public required Ulid Channel { get; init; }

    public required Ulid Author { get; init; }
    
    public Optional<string> Nonce { get; init; }

    public Optional<MessageWebhookApiModel> Webhook { get; init; }

    public Optional<string> Content { get; init; }
    
    //[property: JsonPropertyName("system")] TODO: system property

    public Optional<AttachmentApiModel[]> Attachments { get; init; }

    public Optional<DateTimeOffset> Edited { get; init; }
    
    public Optional<MessageEmbedApiModel[]> Embeds { get; init; }

    public Optional<Ulid[]> Mentions { get; init; }

    public Optional<Ulid[]> Replies { get; init; }

    public Optional<Dictionary<string, Ulid[]>> Reactions { get; init; }

    public Optional<MessageInteractionsApiModel> Interactions { get; init; }

    public Optional<MessageMasqueradeApiModel> Masquerade { get; init; }
}