using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class PartialServerUpdateApiModel : IApiModel
{
    public Optional<Ulid> Owner { get; init; }
    
    public Optional<string> Name { get; init; }

    public Optional<string> Description { get; init; }
    
    //public Optional<ServerChannelCategoryApiModel[]> Categories { get; init; }

    public Optional<ServerSystemMessagesApiModel> SystemMessages { get; init; }
    
    //public Optional<Dictionary<Ulid, ServerRoleApiModel>> Roles { get; init; }

    public Optional<Permission> DefaultPermissions { get; init; }

    public Optional<AttachmentApiModel> Icon { get; init; }
    
    public Optional<AttachmentApiModel> Banner { get; init; }
    
    public Optional<ServerFlag> Flags { get; init; }
    
    public Optional<bool> Nsfw { get; init; }

    public Optional<bool> Analytics { get; init; }

    public Optional<bool> Discoverable { get; init; }
}