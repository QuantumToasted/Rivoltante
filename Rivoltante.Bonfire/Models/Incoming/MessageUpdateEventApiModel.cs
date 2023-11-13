using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record MessageUpdateEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("channel")] Ulid Channel,
    [property: JsonPropertyName("data")] PartialMessageUpdateApiModel Data) : IncomingEventApiModel(IncomingEventType.MessageUpdate);