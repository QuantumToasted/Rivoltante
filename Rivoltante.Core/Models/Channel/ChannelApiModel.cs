using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public class ChannelApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required Ulid Id { get; init; }

    public required string ChannelType { get; init; }

    public Optional<bool> Active { get; init; }

    public Optional<Ulid[]> Recipients { get; init; }

    public Optional<Ulid> LastMessageId { get; init; }

    public Optional<string> Name { get; init; }
    
    public Optional<Ulid> Owner { get; init; }

    public Optional<string> Description { get; init; }

    public Optional<AttachmentApiModel> Icon { get; init; }

    public Optional<Permission> Permissions { get; init; }

    public Optional<bool> Nsfw { get; init; }
    
    public Optional<Ulid> User { get; init; }
    
    public Optional<Ulid> Server { get; init; }

    public Optional<PermissionsApiModel> DefaultPermissions { get; init; }

    public Optional<Dictionary<string, PermissionsApiModel>> RolePermissions { get; init; }
}