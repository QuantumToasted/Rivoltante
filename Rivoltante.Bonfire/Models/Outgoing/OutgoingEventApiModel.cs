using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public abstract record OutgoingEventApiModel(
    [property: JsonPropertyName("type")] OutgoingEventType Type) : ApiModel;