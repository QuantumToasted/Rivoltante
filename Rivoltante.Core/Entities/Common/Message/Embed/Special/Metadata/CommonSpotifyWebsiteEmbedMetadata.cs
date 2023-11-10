namespace Rivoltante.Core;

public sealed class CommonSpotifyWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : CommonWebsiteEmbedMetadata(model)
{
    public string ContentType { get; } = model.ContentType.Value;

    public string Id { get; } = model.ContentType.Value;
}