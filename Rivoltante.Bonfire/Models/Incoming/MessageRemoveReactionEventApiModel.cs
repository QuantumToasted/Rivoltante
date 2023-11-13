using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record MessageRemoveReactionEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("channel_id")] Ulid ChannelId,
    [property: JsonPropertyName("emoji_id")] string EmojiId) : IncomingEventApiModel(IncomingEventType.MessageRemoveReaction);