namespace Rivoltante.Core;

public sealed class MemberIdApiModel : IApiModel
{
    public required Ulid Server { get; init; }
    
    public required Ulid User { get; init; }
}