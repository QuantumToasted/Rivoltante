namespace Rivoltante.Core;

public interface IMessage : IUlidEntity
{
    string? Nonce { get; }
    
    Ulid ChannelId { get; }
    
    Ulid AuthorId { get; }
    
    IMessageWebhook? Webhook { get; }
    
    string? Content { get; }
    
    // TODO: System
    
    IReadOnlyList<IAttachment> Attachments { get; }
    
    DateTimeOffset? LastEdited { get; }
    
    IReadOnlyList<IMessageEmbed> Embeds { get; }
    
    IReadOnlyList<Ulid> MentionedUserIds { get; }
    
    IReadOnlyList<Ulid> MessageIdsRepliedTo { get; }
    
    IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>> Reactions { get; }
}