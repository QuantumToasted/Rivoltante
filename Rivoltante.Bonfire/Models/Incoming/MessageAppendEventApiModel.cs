using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record MessageAppendEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("channel")] Ulid Channel,
    [property: JsonPropertyName("append")] PartialMessageAppendApiModel Append) : IncomingEventApiModel(IncomingEventType.MessageAppend);