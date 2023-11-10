namespace Rivoltante.Core;

public abstract class CommonWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : IWebsiteEmbedMetadata
{
    public EmbedWebsiteSpecialType Type { get; } = model.Type;

    public static IWebsiteEmbedMetadata Create(MessageWebsiteEmbedSpecialApiModel model)
    {
        return model.Type switch
        {
            EmbedWebsiteSpecialType.GIF => new CommonGIFWebsiteEmbedMetadata(model),
            EmbedWebsiteSpecialType.YouTube => new CommonYouTubeWebsiteEmbedMetadata(model),
            EmbedWebsiteSpecialType.Lightspeed => new CommonLightspeedWebsiteEmbedMetadata(model),
            EmbedWebsiteSpecialType.Twitch => new CommonTwitchWebsiteEmbedMetadata(model),
            EmbedWebsiteSpecialType.Spotify => new CommonSpotifyWebsiteEmbedMetadata(model),
            EmbedWebsiteSpecialType.Soundcloud => new CommonSoundcloudWebsiteEmbedMetadata(model),
            EmbedWebsiteSpecialType.Bandcamp => new CommonBandcampWebsiteEmbedMetadata(model),
            EmbedWebsiteSpecialType.Streamable => new CommonStreamableWebsiteEmbedMetadata(model),
            _ => new CommonUnknownWebsiteEmbedMetadata(model)
        };
    }
}