using System.Text.Json.Serialization;

namespace Rivoltante.Bonfire;

public sealed record BulkEventApiModel([property: JsonPropertyName("v")] IncomingEventApiModel[] V) : IncomingEventApiModel(IncomingEventType.Bulk);