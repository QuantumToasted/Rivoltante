namespace Rivoltante.Core;

public sealed record RevoltMessage(
    Optional<string> Content = default, 
    Optional<IEnumerable<string>> Attachments = default, 
    Optional<IEnumerable<RevoltMessageReply>> Replies = default, 
    Optional<IEnumerable<RevoltMessageEmbed>> Embeds = default,
    Optional<RevoltMessageMasquerade> Masquerade = default, 
    Optional<RevoltMessageInteractions> Interactions = default);