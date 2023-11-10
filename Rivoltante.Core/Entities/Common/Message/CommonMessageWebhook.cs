namespace Rivoltante.Core;

public class CommonMessageWebhook : IMessageWebhook
{
    internal CommonMessageWebhook(MessageWebhookApiModel model)
    {
        Name = model.Name;
        Avatar = model.Avatar.GetValueOrDefault();
    }
    
    public string Name { get; }
    
    public string? Avatar { get; }
}