using Rivoltante.Core;

namespace Rivoltante.Rest.Message;

public abstract class RestMessageEmbed : IMessageEmbed
{
    protected internal RestMessageEmbed(MessageEmbedApiModel model)
    {
        Type = model.Type;
    }

    public string Type { get; }

    public static RestMessageEmbed Create(MessageEmbedApiModel model)
    {
        return model switch
        {
            MessageImageEmbedApiModel imageEmbedModel => new RestMessageImageEmbed(imageEmbedModel),
            MessageTextEmbedApiModel textEmbedModel => new RestMessageTextEmbed(textEmbedModel),
            MessageVideoEmbedApiModel videoEmbedModel => new RestMessageVideoEmbed(videoEmbedModel),
            MessageWebsiteEmbedApiModel websiteEmbedModel => new RestMessageWebsiteEmbed(websiteEmbedModel),
            _ => new RestMessageUnknownEmbed(model)
        };
    }
}