namespace Rivoltante.Core;

public sealed record RevoltMessage(
    string? Content = null, 
    IList<string>? Attachments = null, 
    IList<RevoltMessageReply>? Replies = null, 
    IList<RevoltMessageEmbed>? Embeds = null,
    RevoltMessageMasquerade? Masquerade = null, 
    RevoltMessageInteractions? Interactions = null);