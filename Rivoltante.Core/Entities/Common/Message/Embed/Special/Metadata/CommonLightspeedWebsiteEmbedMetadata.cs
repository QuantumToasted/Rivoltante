namespace Rivoltante.Core;

public sealed class CommonLightspeedWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : CommonWebsiteEmbedMetadata(model)
{
    public string ChannelId { get; } = model.Id.Value;
}