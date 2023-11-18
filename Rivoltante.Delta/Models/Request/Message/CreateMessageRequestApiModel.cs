using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class CreateMessageRequestApiModel : IApiModel, IHeaderMetadata
{
    public IReadOnlyDictionary<string, string> Headers => new Dictionary<string, string> { ["Idempotency-Key"] = Ulid.FromGuid(Guid.NewGuid()) };

    public Optional<string> Content { get; init; }

    public Optional<string[]> Attachments { get; init; }

    public Optional<CreateMessageReplyRequestApiModel[]> Replies { get; init; }

    public Optional<CreateMessageEmbedRequestApiModel[]> Embeds { get; init; }

    public Optional<MessageMasqueradeApiModel> Masquerade { get; init; }

    public Optional<MessageInteractionsApiModel> Interactions { get; init; }
}