using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ChannelDeleteEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id) : IncomingEventApiModel(IncomingEventType.ChannelDelete);