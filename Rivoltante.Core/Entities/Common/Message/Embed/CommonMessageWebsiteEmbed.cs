﻿namespace Rivoltante.Core;

public class CommonMessageWebsiteEmbed : CommonMessageEmbed
{
    public CommonMessageWebsiteEmbed(MessageEmbedApiModel model) 
        : base(model)
    {
        Url = model.Url.GetValueOrDefault();
        OriginalUrl = model.OriginalUrl.GetValueOrDefault();
        Metadata = Optional<IWebsiteEmbedMetadata>.ConvertOrDefault(model.Special, CommonWebsiteEmbedMetadata.Create);
        Title = model.Title.GetValueOrDefault();
        Description = model.Description.GetValueOrDefault();
        Media = Optional<CommonMessageEmbedImage>.ConvertOrDefault(model.Image, static m => new CommonMessageEmbedImage(m))
                ?? Optional<CommonMessageEmbedVideo>.ConvertOrDefault(model.Video, static m => new CommonMessageEmbedVideo(m)) as IMessageEmbedMedia;
        SiteName = model.SiteName.GetValueOrDefault();
        IconUrl = model.IconUrl.GetValueOrDefault();
        Color = model.Color.GetValueOrDefault();
    }
    
    public string? Url { get; }
    
    public string? OriginalUrl { get; }
    
    public IWebsiteEmbedMetadata? Metadata { get; }
    
    public string? Title { get; }
    
    public string? Description { get; }
    
    public IMessageEmbedMedia? Media { get; }
    
    public string? SiteName { get; }
    
    public string? IconUrl { get; }
    
    public string? Color { get; }
}