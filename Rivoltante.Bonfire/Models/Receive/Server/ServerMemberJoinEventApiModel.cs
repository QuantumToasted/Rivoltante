﻿using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerMemberJoinEventApiModel : IReceiveEventApiModel
{
    public required Ulid Id { get; init; }
    
    public required Ulid User { get; init; }

    public ReceiveEventType? Type => ReceiveEventType.ServerMemberJoin;
}