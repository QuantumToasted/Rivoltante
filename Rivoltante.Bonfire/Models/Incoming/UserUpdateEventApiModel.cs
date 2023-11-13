using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record UserUpdateEventApiModel(
    [property: JsonPropertyName("id")] Ulid Id,
    [property: JsonPropertyName("data")] PartialUserUpdateApiModel Data,
    [property: JsonPropertyName("clear")] RemovedUserField[] Clear) : IncomingEventApiModel(IncomingEventType.UserUpdate);