namespace Rivoltante.Core;

public class CommonPermissionOverride(Permission allowed, Permission denied) : IPermissionOverride
{
    public Permission Allowed { get; } = allowed;
    
    public Permission Denied { get; } = denied;
}