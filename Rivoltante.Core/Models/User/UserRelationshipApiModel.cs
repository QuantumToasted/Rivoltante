using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class UserRelationshipApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required Ulid Id { get; init; }
    
    public required UserRelationshipStatus Status { get; init; }
}