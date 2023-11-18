namespace Rivoltante.Core;

public sealed class EmojiParentApiModel : IApiModel
{
    public required EmojiParentType Type { get; init; }
    
    public Optional<Ulid> Id { get; init; }
}