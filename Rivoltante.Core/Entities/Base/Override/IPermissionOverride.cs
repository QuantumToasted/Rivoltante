namespace Rivoltante.Core;

public interface IPermissionOverride
{
    Permissions Allowed { get; }
    
    Permissions Denied { get; }
}