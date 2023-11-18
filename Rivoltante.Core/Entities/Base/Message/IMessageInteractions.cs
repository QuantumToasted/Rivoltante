namespace Rivoltante.Core;

public interface IMessageInteractions
{
    IReadOnlyList<IEmoji> Reactions { get; }
    
    bool RestrictReactions { get; }
}