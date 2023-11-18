using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageUnreactedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<MessageUnreactEventApiModel, MessageUnreactedEventArgs>(eventManager)
{
    public override ValueTask<MessageUnreactedEventArgs?> HandleAsync(IBonfireClient client, MessageUnreactEventApiModel model)
    {
        var e = new MessageUnreactedEventArgs(model.Id, model.ChannelId, model.UserId, Ulid.TryParse(model.EmojiId, out var id)
            ? new CustomEmoji(id)
            : new UnicodeEmoji(model.EmojiId));

        return new(e);
    }
}