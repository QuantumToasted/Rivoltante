namespace Rivoltante.Core;

public sealed class MessageInteractionsApiModel : IApiModel
{
    public Optional<string[]> Reactions { get; init; }

    public Optional<bool> RestrictReactions { get; init; }
}