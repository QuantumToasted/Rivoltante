namespace Rivoltante.Core;

public class MessageInteractionsApiModel : IApiModel
{
    public Optional<string[]> Reactions { get; init; }

    public Optional<bool> RestrictReactions { get; init; }
}