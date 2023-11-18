using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class EmojiCreateEventApiModel : EmojiApiModel, IReceiveEventApiModel
{
    public ReceiveEventType? Type => ReceiveEventType.EmojiCreate;
}