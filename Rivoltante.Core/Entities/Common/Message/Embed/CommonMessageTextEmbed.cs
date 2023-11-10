namespace Rivoltante.Core;

public class CommonMessageTextEmbed : CommonMessageEmbed
{
    internal CommonMessageTextEmbed(MessageTextEmbedApiModel model) 
        : base(model)
    {
        IconUrl = model.IconUrl.GetValueOrDefault();
        Url = model.IconUrl.GetValueOrDefault();
        Title = model.Title.GetValueOrDefault();
        Description = model.Description.GetValueOrDefault();
        Media = model.Media.GetValueOrDefault();
        Color = model.Color.GetValueOrDefault();
    }
    
    public string? IconUrl { get; }
    
    public string? Url { get; }
    
    public string? Title { get; }
    
    public string? Description { get; }
    
    public string? Media { get; }
    
    public string? Color { get; }
}