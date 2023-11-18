using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class EditMessageRequestApiModel : IApiModel
{
    public Optional<string> Content { get; init; }

    public Optional<MessageEmbedApiModel> Embeds { get; init; }
}