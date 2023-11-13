using System.Text.Json.Serialization;

namespace Rivoltante.Bonfire;

public record PingEventApiModel(
    [property: JsonPropertyName("data")] long Data) : OutgoingEventApiModel(OutgoingEventType.Ping); // Data is a timestamp