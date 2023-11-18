using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class CreateMessageEmbedRequestApiModel : IApiModel
{
    public Optional<string> IconUrl { get; init; }

    public Optional<string> Url { get; init; }
    
    public Optional<string> Title { get; init; }

    public Optional<string> Description { get; init; }

    public Optional<string> Media { get; init; }
    
    [JsonPropertyName("colour")] 
    public Optional<string> Color { get; init; }
}