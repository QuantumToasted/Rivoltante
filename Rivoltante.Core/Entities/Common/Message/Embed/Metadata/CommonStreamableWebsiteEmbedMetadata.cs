namespace Rivoltante.Core;

public sealed class CommonStreamableWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : CommonWebsiteEmbedMetadata(model)
{
    public string Id { get; } = model.Id.Value;
}