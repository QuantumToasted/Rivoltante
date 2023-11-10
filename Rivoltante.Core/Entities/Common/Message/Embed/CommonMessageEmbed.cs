namespace Rivoltante.Core;

public abstract class CommonMessageEmbed : IMessageEmbed
{
    protected internal CommonMessageEmbed(MessageEmbedApiModel model)
    {
        Type = model.Type;
    }

    public string Type { get; }

    public static CommonMessageEmbed Create(MessageEmbedApiModel model)
    {
        return model switch
        {
            MessageImageEmbedApiModel imageEmbedModel => new CommonMessageImageEmbed(imageEmbedModel),
            MessageTextEmbedApiModel textEmbedModel => new CommonMessageTextEmbed(textEmbedModel),
            MessageVideoEmbedApiModel videoEmbedModel => new CommonMessageVideoEmbed(videoEmbedModel),
            MessageWebsiteEmbedApiModel websiteEmbedModel => new CommonMessageWebsiteEmbed(websiteEmbedModel),
            _ => new CommonMessageUnknownEmbed(model)
        };
    }
}