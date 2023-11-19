using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class SetChannelRolePermissionsRequestApiModel : IApiModel
{
    public required PermissionsApiModel Permissions { get; init; }
}