using Rivoltante.Core;

namespace Rivoltante.Delta;

public class SetChannelRolePermissionsRequestApiModel : IApiModel
{
    public required PermissionsApiModel Permissions { get; init; }
}