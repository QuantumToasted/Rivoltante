using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record UserBotInformationApiModel(
    [property: JsonPropertyName("owner")] Ulid Owner) : ApiModel;