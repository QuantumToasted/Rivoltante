using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class PartialMessageUpdateApiModel : IApiModel
{
    public Optional<string> Content { get; init; }

    public Optional<AttachmentApiModel[]> Attachments { get; init; }

    public Optional<MessageEmbedApiModel[]> Embeds { get; init; }

    public Optional<Ulid[]> Mentions { get; init; }
    
    //[JsonPropertyName("interactions")]
    //public Optional<MessageInteractionsApiModel> Interactions { get; init; }

    public Optional<Ulid[]> Replies { get; init; }

    public Optional<DateTimeOffset> Edited { get; init; }

    public Optional<MessageMasqueradeApiModel> Masquerade { get; init; }
}