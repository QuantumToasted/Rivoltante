using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public record ServerMemberUpdateEventApiModel(
    [property: JsonPropertyName("id")] MemberIdApiModel Id,
    [property: JsonPropertyName("data")] PartialMemberUpdateApiModel Data,
    [property: JsonPropertyName("clear")] RemovedMemberField[] Clear) : IncomingEventApiModel(IncomingEventType.ServerMemberUpdate);