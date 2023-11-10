namespace Rivoltante.Core;

public sealed record RevoltMessageInteractions(
    ISet<string> Reactions,
    bool RestrictReactions);