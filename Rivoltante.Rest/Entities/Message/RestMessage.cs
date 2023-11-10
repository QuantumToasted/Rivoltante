using Rivoltante.Core;
using Rivoltante.Core.Emoji;

namespace Rivoltante.Rest.Message;

public class RestMessage : IMessage
{
    internal RestMessage(IRevoltClient client, MessageApiModel model)
    {
        Id = model.Id;
        Client = client;
        Nonce = model.Nonce.GetValueOrDefault();
        ChannelId = model.Channel;
        AuthorId = model.Author;
        Webhook = Optional<RestMessageWebhook>.ConvertOrDefault(model.Webhook, static m => new RestMessageWebhook(m));
        Content = model.Content.GetValueOrDefault();
        Attachments = Optional<IReadOnlyList<RestAttachment>>.ConvertOrFallback(model.Attachments,
            static m => m.Select(static x => new RestAttachment(x)).ToList(), new List<RestAttachment>());
        LastEdited = model.Edited.GetValueOrNullable();
        Embeds = Optional<IReadOnlyList<RestMessageEmbed>>.ConvertOrFallback(model.Embeds, static m => m.Select(RestMessageEmbed.Create).ToList(),
            new List<RestMessageEmbed>());
        MentionedUserIds =
            Optional<IReadOnlyList<Ulid>>.ConvertOrFallback(model.Mentions, static m => m.Select(Ulid.Parse).ToList(), new List<Ulid>());
        MessageIdsRepliedTo = Optional<IReadOnlyList<Ulid>>.ConvertOrFallback(model.Replies, static m => m.Select(Ulid.Parse).ToList(), new List<Ulid>());
        Reactions = Optional<IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>>>
            .ConvertOrFallback<Dictionary<string, string[]>, IReadOnlyDictionary<IEmoji, IReadOnlyList<Ulid>>>(model.Reactions,
                static m => m.ToDictionary(
                    static x => CustomEmoji.TryParse(x.Key, out var em) ? em : (IEmoji)new UnicodeEmoji(x.Key),
                    static x => (IReadOnlyList<Ulid>)x.Value.Select(Ulid.Parse).ToList()), new Dictionary<IEmoji, IReadOnlyList<Ulid>>());
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