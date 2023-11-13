﻿using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ChannelStopTypingEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("user")] Ulid User) : IncomingEventApiModel(IncomingEventType.ChannelStopTyping);