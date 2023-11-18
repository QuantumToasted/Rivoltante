namespace Rivoltante.Core;

public class CommonMessageUnknownEmbed(MessageEmbedApiModel model) : CommonMessageEmbed
{
    public string RawEmbedType { get; } = model.Type;
    
    public override EmbedType Type => throw new InvalidOperationException("Unknown message embed type.");
}