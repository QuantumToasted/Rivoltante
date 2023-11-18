namespace Rivoltante.Core;

public sealed class CommonMessage(MessageApiModel model, IRevoltClient client) : IMessage
{
    public IRevoltClient Client { get; } = client;
    
    public Ulid Id { get; } = model.Id;
    
    public string? Nonce { get; } = model.Nonce.GetValueOrDefault();
    
    public Ulid ChannelId { get; } = model.Channel;
    
    public Ulid AuthorId { get; } = model.Author;
    
    public IMessageWebhook? Webhook { get; } = Optional<CommonMessageWebhook>.ConvertOrDefault(model.Webhook, static m => new CommonMessageWebhook(m));
    
    public string? Content { get; } = model.Content.GetValueOrDefault();
    
    public IReadOnlyList<IAttachment> Attachments { get; } = Optional<IReadOnlyList<CommonAttachment>>.ConvertOrFallback(model.Attachments,
        static m => m.Select(static x => new CommonAttachment(x)).ToList(), new List<CommonAttachment>());
    
    public DateTimeOffset? LastEdited { get; } = model.Edited.GetValueOrNullable();

    public IReadOnlyList<IMessageEmbed> Embeds { get; } = Optional<IReadOnlyList<IMessageEmbed>>.ConvertOrFallback(model.Embeds,
        static m => m.Select(CommonMessageEmbed.Create).ToList(),
        new List<IMessageEmbed>());
    
    public IReadOnlyList<Ulid> MentionedUserIds { get; } = Optional<IReadOnlyList<Ulid>>.ConvertOrFallback(model.Mentions, static m => m.ToList(), new List<Ulid>());
    
    public IReadOnlyList<Ulid> MessageIdsRepliedTo { get; } = Optional<IReadOnlyList<Ulid>>.ConvertOrFallback(model.Replies, static m => m.ToList(), new List<Ulid>());

    public IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>> Reactions { get; } = Optional<IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>>>
        .ConvertOrFallback<Dictionary<string, Ulid[]>, IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>>>(model.Reactions,
            static m => m.ToDictionary(
                static x => CustomEmoji.TryParse(x.Key, out var em) ? em : (IEmoji)new UnicodeEmoji(x.Key),
                static x => (IReadOnlyList<Ulid>)x.Value.ToList()), new Dictionary<IEmoji, IReadOnlyList<Ulid>>());
}