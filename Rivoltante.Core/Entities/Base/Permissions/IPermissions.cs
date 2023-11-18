namespace Rivoltante.Core;

public interface IPermissions
{
    Permission AllowedPermissions { get; }
    
    Permission DeniedPermissions { get; }
}