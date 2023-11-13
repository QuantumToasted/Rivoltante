using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed record EndTypingEventApiModel(
    [property: JsonPropertyName("channel")] Ulid ChannelId) : OutgoingEventApiModel(OutgoingEventType.EndTyping);