using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class MessageEmbedApiModel : IApiModel
{
    public required string Type { get; init; }
    
    public Optional<string> Url { get; init; }

    public Optional<string> OriginalUrl { get; init; }

    public Optional<MessageWebsiteEmbedSpecialApiModel> Special { get; init; }

    public Optional<string> Title { get; init; }

    public Optional<string> Description { get; init; }

    public Optional<MessageEmbedImageApiModel> Image { get; init; }
    
    public Optional<MessageEmbedVideoApiModel> Video { get; init; }

    public Optional<string> SiteName { get; init; }

    public Optional<string> IconUrl { get; init; }

    [JsonPropertyName("colour")] 
    public Optional<string> Color { get; init; }
    
    public Optional<int> Width { get; init; }
    
    public Optional<int> Height { get; init; }
    
    public Optional<AttachmentApiModel> Media { get; init; }
    
    public Optional<EmbedImageSize> Size { get; init; }
}