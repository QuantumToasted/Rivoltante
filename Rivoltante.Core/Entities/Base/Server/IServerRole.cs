namespace Rivoltante.Core;

public interface IServerRole : IUlidEntity, IServerEntity
{
    string Name { get; }
    
    IPermissions Permissions { get; }
    
    string? Color { get; }
    
    public bool IsHoisted { get; }
    
    public long Rank { get; }
}