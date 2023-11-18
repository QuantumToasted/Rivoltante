namespace Rivoltante.Core;

public class MessageWebhookApiModel : IApiModel
{
    public required string Name { get; init; }
    
    public Optional<string> Avatar { get; init; }
}