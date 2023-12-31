﻿namespace Rivoltante.Core;

public class CommonMessageTextEmbed(MessageEmbedApiModel model) : CommonMessageEmbed(model)
{
    public string? IconUrl { get; } = model.IconUrl.GetValueOrDefault();
    
    public string? Url { get; } = model.IconUrl.GetValueOrDefault();
    
    public string? Title { get; } = model.Title.GetValueOrDefault();
    
    public string? Description { get; } = model.Description.GetValueOrDefault();
    
    public IAttachment? Media { get; } = Optional<IAttachment>.ConvertOrDefault(model.Media, x => new CommonAttachment(x));
    
    public string? Color { get; } = model.Color.GetValueOrDefault();
}