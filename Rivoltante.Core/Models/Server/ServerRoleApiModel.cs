using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class ServerRoleApiModel : IApiModel
{
    public required string Name { get; init; }

    public required PermissionsApiModel Permissions { get; init; }

    [JsonPropertyName("colour")]
    public Optional<string> Color { get; init; }
    
    public Optional<bool> Hoist { get; init; }
    
    public required long Rank { get; init; }
}