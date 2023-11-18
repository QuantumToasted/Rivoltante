namespace Rivoltante.Core;

public sealed class CommonPermissions(PermissionsApiModel model) : IPermissions
{
    public Permission AllowedPermissions { get; } = model.Allow;

    public Permission DeniedPermissions { get; } = model.Deny;
}