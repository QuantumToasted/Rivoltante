using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class EmojiCreatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<EmojiCreateEventApiModel, EmojiCreatedEventArgs>(eventManager)
{
    public override ValueTask<EmojiCreatedEventArgs?> HandleAsync(IBonfireClient client, EmojiCreateEventApiModel model)
    {
        var e = new EmojiCreatedEventArgs(new CommonServerEmoji(model, client));
        return new(e);
    }
}