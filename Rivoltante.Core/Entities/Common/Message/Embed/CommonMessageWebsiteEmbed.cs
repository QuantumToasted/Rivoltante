namespace Rivoltante.Core;

public sealed class CommonMessageWebsiteEmbed(MessageEmbedApiModel model) : CommonMessageEmbed
{
    public string? Url { get; } = model.Url.GetValueOrDefault();
    
    public string? OriginalUrl { get; } = model.OriginalUrl.GetValueOrDefault();
    
    public IWebsiteEmbedMetadata? Metadata { get; } = Optional<IWebsiteEmbedMetadata>.ConvertOrDefault(model.Special, CommonWebsiteEmbedMetadata.Create);
    
    public string? Title { get; } = model.Title.GetValueOrDefault();
    
    public string? Description { get; } = model.Description.GetValueOrDefault();

    public IMessageEmbedMedia? Media { get; } =
        Optional<CommonMessageEmbedImage>.ConvertOrDefault(model.Image, static m => new CommonMessageEmbedImage(m))
        ?? Optional<CommonMessageEmbedVideo>.ConvertOrDefault(model.Video, static m => new CommonMessageEmbedVideo(m)) as IMessageEmbedMedia;
    
    public string? SiteName { get; } = model.SiteName.GetValueOrDefault();
    
    public string? IconUrl { get; } = model.IconUrl.GetValueOrDefault();
    
    public string? Color { get; } = model.Color.GetValueOrDefault();

    public override EmbedType Type => EmbedType.Website;
}