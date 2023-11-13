using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed record ErrorEventApiModel([property: JsonPropertyName("error")] ErrorEventId Error) : IncomingEventApiModel(IncomingEventType.Error);