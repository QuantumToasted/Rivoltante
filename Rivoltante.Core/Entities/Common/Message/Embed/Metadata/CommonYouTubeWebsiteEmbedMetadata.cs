namespace Rivoltante.Core;

public sealed class CommonYouTubeWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : CommonWebsiteEmbedMetadata(model)
{
    public string VideoId { get; } = model.Id.Value;
    
    public TimeOnly? Timestamp { get; } = Optional<TimeOnly>.ConvertOrDefault(model.Timestamp, 
        x => TimeOnly.FromTimeSpan(TimeSpan.FromSeconds(int.Parse(x))));
}