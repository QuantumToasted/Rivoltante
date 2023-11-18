﻿using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelAckEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }
    
    public required Ulid User { get; init; }

    public required Ulid MessageId { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ChannelAck;
}