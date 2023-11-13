using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ReadyEventApiModel(
    [property: JsonPropertyName("users")] UserApiModel[] Users,
    [property: JsonPropertyName("servers")] ServerApiModel[] Servers,
    [property: JsonPropertyName("channels")] ChannelApiModel[] Channels,
    [property: JsonPropertyName("emojis")] Optional<EmojiApiModel[]> Emojis) : IncomingEventApiModel(IncomingEventType.Ready);