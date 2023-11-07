using Rivoltante.Core;

namespace Rivoltante.Rest.Message;

public class RestMessageUnknownEmbed : RestMessageEmbed
{
    internal RestMessageUnknownEmbed(MessageEmbedApiModel model) 
        : base(model)
    { }
    
    public string Type { get; }
}