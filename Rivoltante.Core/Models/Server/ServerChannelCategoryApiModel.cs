namespace Rivoltante.Core;

public sealed class ServerChannelCategoryApiModel : IApiModel
{
    public required Ulid Id { get; init; }
    
    public required string Title { get; init; }

    public required Ulid[] Channels { get; init; }
}