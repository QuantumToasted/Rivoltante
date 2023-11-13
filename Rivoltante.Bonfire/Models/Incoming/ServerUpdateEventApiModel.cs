using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ServerUpdateEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("data")] PartialServerUpdateApiModel Data,
    [property: JsonPropertyName("clear")] RemovedServerField[] Clear) : IncomingEventApiModel(IncomingEventType.ServerUpdate);