using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ChannelUpdateEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("data")] PartialChannelUpdateApiModel Data,
    [property: JsonPropertyName("clear")] RemovedChannelField[] Clear) : IncomingEventApiModel(IncomingEventType.ChannelUpdate);