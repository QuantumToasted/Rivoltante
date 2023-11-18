using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class BulkDeleteMessagesRequestApiModel : IApiModel
{
    public required Ulid[] Ids { get; init; }
}