using Newtonsoft.Json;

namespace Rivoltante.Core;

public record UserBotInformationApiModel(
    [property: JsonProperty("owner")] Ulid Owner) : ApiModel;