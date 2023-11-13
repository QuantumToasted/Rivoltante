using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ChannelAckEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("user")] Ulid User,
    [property: JsonPropertyName("message_id")] Ulid MessageId) : IncomingEventApiModel(IncomingEventType.ChannelAck);