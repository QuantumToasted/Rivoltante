namespace Rivoltante.Core;

public interface IServerRole : IServerEntity, IUlidEntity
{
    string Name { get; }
    
    IPermissionOverride Permissions { get; }
    
    string? Color { get; }
    
    public bool IsHoisted { get; }
    
    public long Rank { get; }
}