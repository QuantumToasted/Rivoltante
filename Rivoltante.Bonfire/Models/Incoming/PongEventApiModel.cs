using System.Text.Json.Serialization;

namespace Rivoltante.Bonfire;

public record PongEventApiModel([property: JsonPropertyName("data")] long Data) : IncomingEventApiModel(IncomingEventType.Pong);