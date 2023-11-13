using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ServerDeleteEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id) : IncomingEventApiModel(IncomingEventType.ServerDelete);