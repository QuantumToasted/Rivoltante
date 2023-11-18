using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelDeleteEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ChannelDelete;
}