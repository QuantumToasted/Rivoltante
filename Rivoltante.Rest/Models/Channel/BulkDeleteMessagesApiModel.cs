using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record BulkDeleteMessagesApiModel(
    [property: JsonProperty("ids")] Ulid[] Ids) : ApiModel;