namespace Rivoltante.Core;

public class CommonPermissionOverride(Permissions allowed, Permissions denied) : IPermissionOverride
{
    public Permissions Allowed { get; } = allowed;
    
    public Permissions Denied { get; } = denied;
}