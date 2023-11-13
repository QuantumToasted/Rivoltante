namespace Rivoltante.Core;

public class CommonMessageWebhook(MessageWebhookApiModel model) : IMessageWebhook
{
    public string Name { get; } = model.Name;

    public string? Avatar { get; } = model.Avatar.GetValueOrDefault();
}