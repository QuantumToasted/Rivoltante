using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class SearchChannelMessagesRequestApiModel : IApiModel
{
    public required string Query { get; init; }
    
    public Optional<int> Limit { get; init; }
    
    public Optional<Ulid> Before { get; init; }
    
    public Optional<Ulid> After { get; init; }
    
    public Optional<MessageSortOrder> Sort { get; init; }
    
    public Optional<bool> IncludeUsers { get; init; }
}