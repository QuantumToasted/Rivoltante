using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record UserPlatformWipeEventApiModel(
    [property: JsonPropertyName("user_id")] Ulid UserId,
    [property: JsonPropertyName("flags")] string Flags) : IncomingEventApiModel(IncomingEventType.UserPlatformWipe);