namespace Rivoltante.Core;

public sealed class RevoltMessage
{
    public string? Content { get; set; }

    public IList<string>? Attachments { get; set; }

    public IList<RevoltMessageReply>? Replies { get; set; }

    public IList<RevoltMessageEmbed>? Embeds { get; set; }
    
    public RevoltMessageMasquerade? Masquerade { get; set; }
    
    public RevoltMessageInteractions? Interactions { get; set; }
}