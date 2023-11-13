using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record EmojiDeleteEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id) : IncomingEventApiModel(IncomingEventType.EmojiDelete);