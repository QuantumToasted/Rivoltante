using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class EmojiDeletedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<EmojiDeleteEventApiModel, EmojiDeletedEventArgs>(eventManager)
{
    public override ValueTask<EmojiDeletedEventArgs?> HandleAsync(IBonfireClient client, EmojiDeleteEventApiModel model)
    {
        var e = new EmojiDeletedEventArgs(model.Id);
        return new(e);
    }
}