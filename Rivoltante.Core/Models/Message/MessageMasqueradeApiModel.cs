using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public class MessageMasqueradeApiModel : IApiModel
{
    public Optional<string> Name { get; init; }
    
    public Optional<string> Avatar { get; init; }
    
    [JsonPropertyName("colour")] 
    public Optional<string> Color { get; init; }
}