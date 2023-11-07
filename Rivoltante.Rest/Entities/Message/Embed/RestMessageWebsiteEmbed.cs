using Rivoltante.Core;

namespace Rivoltante.Rest.Message;

public class RestMessageWebsiteEmbed : RestMessageEmbed
{
    internal RestMessageWebsiteEmbed(MessageWebsiteEmbedApiModel model) 
        : base(model)
    {
        Url = model.Url.GetValueOrDefault();
        OriginalUrl = model.OriginalUrl.GetValueOrDefault();
        Title = model.Title.GetValueOrDefault();
        Description = model.Description.GetValueOrDefault();
        Media = Optional<RestMessageEmbedImage>.ConvertOrDefault(model.Image, static m => new RestMessageEmbedImage(m))
                ?? Optional<RestMessageEmbedVideo>.ConvertOrDefault(model.Video, static m => new RestMessageEmbedVideo(m)) as IMessageEmbedMedia;
        SiteName = model.SiteName.GetValueOrDefault();
        IconUrl = model.IconUrl.GetValueOrDefault();
        Color = model.Color.GetValueOrDefault();
    }
    
    public string? Url { get; }
    
    public string? OriginalUrl { get; }
    
    // TODO: Special
    
    public string? Title { get; }
    
    public string? Description { get; }
    
    public IMessageEmbedMedia? Media { get; }
    
    public string? SiteName { get; }
    
    public string? IconUrl { get; }
    
    public string? Color { get; }
}