using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ReadyEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ReadyEventApiModel, ReadyEventArgs>(eventManager)
{
    public override ValueTask<ReadyEventArgs?> HandleAsync(IBonfireClient client, ReadyEventApiModel model)
    {
        var e = new ReadyEventArgs(model.Users.Select(x => new CommonUser(x, client)),
            model.Servers.Select(x => new CommonServer(x, client)),
            model.Channels.Select(x => CommonChannel.Create(x, client)),
            model.Emojis.GetValueOrFallback(Array.Empty<EmojiApiModel>())
                .Select(x => new CommonServerEmoji(x, client)));

        return new(e);
    }
}