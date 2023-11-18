namespace Rivoltante.Core;

public sealed class MessageWebsiteEmbedSpecialApiModel : IApiModel
{
    public required EmbedWebsiteSpecialType Type { get; init; }
    
    public Optional<string> Id { get; init; }

    public Optional<string> Timestamp { get; init; }

    public Optional<string> ContentType { get; init; }
}