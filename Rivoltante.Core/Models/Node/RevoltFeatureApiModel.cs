using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record RevoltFeatureApiModel(
    [property: JsonPropertyName("enabled")] bool Enabled,
    [property: JsonPropertyName("key")] Optional<string> Key,
    [property: JsonPropertyName("url")] Optional<string> Url,
    [property: JsonPropertyName("ws")] Optional<string> Ws) : ApiModel;