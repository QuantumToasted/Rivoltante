using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class PartialServerRoleUpdateApiModel : IApiModel
{
    public Optional<string> Name { get; init; }

    public Optional<PermissionsApiModel> Permissions { get; init; }

    [JsonPropertyName("colour")] 
    public Optional<string> Color { get; init; }
    
    public Optional<bool> Hoist { get; init; }
    
    public Optional<long> Rank { get; init; }
}