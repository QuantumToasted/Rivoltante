namespace Rivoltante.Core;

public sealed class CommonMessageWebhook(MessageWebhookApiModel model) : IMessageWebhook
{
    public string Name { get; } = model.Name;

    public string? Avatar { get; } = model.Avatar.GetValueOrDefault();
}