using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record MessageDeleteEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("channel")] Ulid Channel) : IncomingEventApiModel(IncomingEventType.MessageDelete);