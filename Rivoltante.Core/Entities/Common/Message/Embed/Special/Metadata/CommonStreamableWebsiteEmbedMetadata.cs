namespace Rivoltante.Core;

public class CommonStreamableWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : CommonWebsiteEmbedMetadata(model)
{
    public string Id { get; } = model.Id.Value;
}