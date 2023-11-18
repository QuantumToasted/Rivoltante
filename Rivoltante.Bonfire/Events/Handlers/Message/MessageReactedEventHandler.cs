using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageReactedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<MessageReactEventApiModel, MessageReactedEventArgs>(eventManager)
{
    public override ValueTask<MessageReactedEventArgs?> HandleAsync(IBonfireClient client, MessageReactEventApiModel model)
    {
        var e = new MessageReactedEventArgs(model.Id, model.ChannelId, model.UserId, Ulid.TryParse(model.EmojiId, out var id)
            ? new CustomEmoji(id)
            : new UnicodeEmoji(model.EmojiId));

        return new(e);
    }
}