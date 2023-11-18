using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ReadyEventApiModel : IReceiveEventApiModel
{
    public required UserApiModel[] Users { get; init; }

    public required ServerApiModel[] Servers { get; init; }

    public required ChannelApiModel[] Channels { get; init; }

    public Optional<EmojiApiModel[]> Emojis { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.Ready;
}