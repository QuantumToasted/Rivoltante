using System.Text.Json.Serialization;

namespace Rivoltante.Bonfire;

public sealed record AuthenticateEventApiModel(
    [property: JsonPropertyName("token")] string Token) : OutgoingEventApiModel(OutgoingEventType.Authenticate);