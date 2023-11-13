using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record BulkDeleteMessagesApiModel(
    [property: JsonPropertyName("ids")] Ulid[] Ids) : ApiModel;