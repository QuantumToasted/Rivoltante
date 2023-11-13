using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record MessageWebhookApiModel(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("avatar")] Optional<string> Avatar) : ApiModel;