namespace Rivoltante.Core;

public abstract class CommonMessageEmbed(MessageEmbedApiModel model) : IMessageEmbed
{
    public EmbedType Type { get; } = model.Type;

    public static IMessageEmbed Create(MessageEmbedApiModel model)
    {
        return model.Type switch
        {
            EmbedType.Website => new CommonMessageWebsiteEmbed(model),
            EmbedType.Image => new CommonMessageImageEmbed(model),
            EmbedType.Video => new CommonMessageVideoEmbed(model),
            EmbedType.Text => new CommonMessageTextEmbed(model),
            _ => new CommonMessageUnknownEmbed(model)
        };
    }
}