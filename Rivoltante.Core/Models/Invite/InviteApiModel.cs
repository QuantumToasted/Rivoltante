using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class InviteApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required string Id { get; init; }
    
    public required string Type { get; init; }

    public required Ulid Creator { get; init; }

    public required Ulid Channel { get; init; }

    public Optional<Ulid> Server { get; init; }
}