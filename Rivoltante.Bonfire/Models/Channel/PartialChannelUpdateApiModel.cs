using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class PartialChannelUpdateApiModel : IApiModel
{
    public Optional<bool> Active { get; init; }

    public Optional<Ulid[]> Recipients { get; init; }

    public Optional<Ulid> LastMessageId { get; init; }

    public Optional<string> Name { get; init; }
    
    public Optional<Ulid> Owner { get; init; }

    public Optional<string> Description { get; init; }

    public Optional<AttachmentApiModel> Icon { get; init; }

    public Optional<Permission> Permissions { get; init; }

    public Optional<bool> Nsfw { get; init; }

    public Optional<PermissionsApiModel> DefaultPermissions { get; init; }

    public Optional<Dictionary<Ulid, PermissionsApiModel>> RolePermissions { get; init; }
}