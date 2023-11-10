namespace Rivoltante.Core;

public interface IPermissionOverride
{
    Permission Allowed { get; }
    
    Permission Denied { get; }
}