using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class BonfireMessage : IBonfireMessage
{
    public BonfireMessage(IBonfireClient client, MessageEventApiModel model)
    {
        Client = client;
        Update(model);
    }
    
    public IBonfireClient Client { get; }
    
    public Ulid Id { get; private set; }
    
    public string? Nonce { get; private set; }
    
    public Ulid ChannelId { get; private set; }
    
    public Ulid AuthorId { get; private set; }
    
    public IMessageWebhook? Webhook { get; private set; }
    
    public string? Content { get; private set; }
    
    public IReadOnlyList<IAttachment> Attachments { get; private set; } = new List<IAttachment>();

    public DateTimeOffset? LastEdited { get; private set; }
    
    public IReadOnlyList<IMessageEmbed> Embeds { get; private set; } = new List<IMessageEmbed>();

    public IReadOnlyList<Ulid> MentionedUserIds { get; private set; } = new List<Ulid>();

    public IReadOnlyList<Ulid> MessageIdsRepliedTo { get; private set; } = new List<Ulid>();

    public IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>> Reactions { get; private set; } = null!;

    public void Update(MessageEventApiModel model)
    {
        Id = model.Id;
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
    
    public void Update(MessageUpdateEventApiModel model)
    {
        var updateData = model.Data;

        if (updateData.Content.HasValue)
            Content = updateData.Content.Value;

        if (updateData.Attachments.HasValue)
            Attachments = updateData.Attachments.Value.Select(x => new CommonAttachment(x)).ToList();

        if (updateData.Edited.HasValue)
            LastEdited = updateData.Edited.Value;

        if (updateData.Embeds.HasValue)
            Embeds = updateData.Embeds.Value.Select(CommonMessageEmbed.Create).ToList();

        if (updateData.Mentions.HasValue)
            MentionedUserIds = updateData.Mentions.Value;

        if (updateData.Replies.HasValue)
            MessageIdsRepliedTo = updateData.Replies.Value;
    }

    public void Update(MessageAppendEventApiModel model)
    {
        var appendData = model.Append;
        
        if (appendData.Embeds.HasValue)
            Embeds = appendData.Embeds.Value.Select(CommonMessageEmbed.Create).ToList();
    }
}