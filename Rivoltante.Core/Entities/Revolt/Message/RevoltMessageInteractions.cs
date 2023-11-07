namespace Rivoltante.Core;

public sealed class RevoltMessageInteractions
{
    public ISet<string> Reactions { get; set; } = new HashSet<string>();
    
    public bool RestrictReactions { get; set; }
}