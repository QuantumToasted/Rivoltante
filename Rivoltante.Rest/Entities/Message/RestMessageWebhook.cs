using Rivoltante.Core;

namespace Rivoltante.Rest.Message;

public class RestMessageWebhook : IMessageWebhook
{
    internal RestMessageWebhook(MessageWebhookApiModel model)
    {
        Name = model.Name;
        Avatar = model.Avatar.GetValueOrDefault();
    }
    
    public string Name { get; }
    
    public string? Avatar { get; }
}