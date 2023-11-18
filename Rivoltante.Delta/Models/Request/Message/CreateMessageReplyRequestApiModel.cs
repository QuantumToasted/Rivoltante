using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class CreateMessageReplyRequestApiModel : IApiModel
{
    public required Ulid Id { get; init; }

    public required bool Mention { get; init; }
}