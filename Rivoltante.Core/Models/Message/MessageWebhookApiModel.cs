using Newtonsoft.Json;

namespace Rivoltante.Core;

public record MessageWebhookApiModel(
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("avatar")] Optional<string> Avatar) : ApiModel;