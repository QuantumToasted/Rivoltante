namespace Rivoltante.Core;

public sealed class CommonTwitchWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : CommonWebsiteEmbedMetadata(model)
{
    public TwitchContentType ContentType { get; } = Enum.Parse<TwitchContentType>(model.ContentType.Value);

    public string Id { get; } = model.Id.Value;
}