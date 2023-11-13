namespace Rivoltante.Core;

public sealed class CommonMessage : IMessage
{
    public CommonMessage(IRevoltClient client, MessageApiModel model)
    {
        Id = model.Id;
        Client = client;
        Nonce = model.Nonce.GetValueOrDefault();
        ChannelId = model.Channel;
        AuthorId = model.Author;
        Webhook = Optional<CommonMessageWebhook>.ConvertOrDefault(model.Webhook, static m => new CommonMessageWebhook(m));
        Content = model.Content.GetValueOrDefault();
        Attachments = Optional<IReadOnlyList<CommonAttachment>>.ConvertOrFallback(model.Attachments,
            static m => m.Select(static x => new CommonAttachment(x)).ToList(), new List<CommonAttachment>());
        LastEdited = model.Edited.GetValueOrNullable();
        Embeds = Optional<IReadOnlyList<IMessageEmbed>>.ConvertOrFallback(model.Embeds, static m => m.Select(CommonMessageEmbed.Create).ToList(),
            new List<IMessageEmbed>());
        MentionedUserIds =
            Optional<IReadOnlyList<Ulid>>.ConvertOrFallback(model.Mentions, static m => m.ToList(), new List<Ulid>());
        MessageIdsRepliedTo = Optional<IReadOnlyList<Ulid>>.ConvertOrFallback(model.Replies, static m => m.ToList(), new List<Ulid>());
        Reactions = Optional<IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>>>
            .ConvertOrFallback<Dictionary<string, Ulid[]>, IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>>>(model.Reactions,
                static m => m.ToDictionary(
                    static x => CustomEmoji.TryParse(x.Key, out var em) ? em : (IEmoji)new UnicodeEmoji(x.Key),
                    static x => (IReadOnlyList<Ulid>)x.Value.ToList()), new Dictionary<IEmoji, IReadOnlyList<Ulid>>());
    }
    
    public Ulid Id { get; }
    
    public IRevoltClient Client { get; }
    
    public string? Nonce { get; }
    
    public Ulid ChannelId { get; }
    
    public Ulid AuthorId { get; }
    
    public IMessageWebhook? Webhook { get; }
    
    public string? Content { get; }
    
    public IReadOnlyList<IAttachment> Attachments { get; }
    
    public DateTimeOffset? LastEdited { get; }
    
    public IReadOnlyList<IMessageEmbed> Embeds { get; }
    
    public IReadOnlyList<Ulid> MentionedUserIds { get; }
    
    public IReadOnlyList<Ulid> MessageIdsRepliedTo { get; }
    
    public IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>> Reactions { get; }
}