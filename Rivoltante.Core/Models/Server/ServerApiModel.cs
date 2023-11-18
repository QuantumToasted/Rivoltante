using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public class ServerApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required Ulid Id { get; init; }
    
    public required Ulid Owner { get; init; }
    
    public required string Name { get; init; } 

    public Optional<string> Description { get; init; }

    public required Ulid[] Channels { get; init; }

    public Optional<ServerChannelCategoryApiModel[]> Categories { get; init; }

    public Optional<ServerSystemMessagesApiModel> SystemMessages { get; init; }

    public Optional<Dictionary<Ulid, ServerRoleApiModel>> Roles { get; init; }

    public required Permission DefaultPermissions { get; init; }

    public Optional<AttachmentApiModel> Icon { get; init; }
    
    public Optional<AttachmentApiModel> Banner { get; init; }
    
    public Optional<ServerFlag> Flags { get; init; }
    
    public Optional<bool> Nsfw { get; init; }

    public Optional<bool> Analytics { get; init; }

    public Optional<bool> Discoverable { get; init; }
}