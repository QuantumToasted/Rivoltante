using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageReactionRemovedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<MessageRemoveReactionEventApiModel, MessageReactionRemovedEventArgs>(eventManager)
{
    public override ValueTask<MessageReactionRemovedEventArgs?> HandleAsync(IBonfireClient client, MessageRemoveReactionEventApiModel model)
    {
        var e = new MessageReactionRemovedEventArgs(model.Id, model.ChannelId, Ulid.TryParse(model.EmojiId, out var id)
            ? new CustomEmoji(id)
            : new UnicodeEmoji(model.EmojiId));

        return new(e);
    }
}