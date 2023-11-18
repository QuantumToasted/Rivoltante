namespace Rivoltante.Core;

public abstract class CommonMessageEmbed : IMessageEmbed
{
    public abstract EmbedType Type { get; }

    public static IMessageEmbed Create(MessageEmbedApiModel model)
    {
        EmbedType? type = Enum.TryParse(model.Type, out EmbedType t)
            ? t
            : null;
        
        return type switch
        {
            EmbedType.Website => new CommonMessageWebsiteEmbed(model),
            EmbedType.Image => new CommonMessageImageEmbed(model),
            EmbedType.Video => new CommonMessageVideoEmbed(model),
            EmbedType.Text => new CommonMessageTextEmbed(model),
            _ => new CommonMessageUnknownEmbed(model)
        };
    }
}