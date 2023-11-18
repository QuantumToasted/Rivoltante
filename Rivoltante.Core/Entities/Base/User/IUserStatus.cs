namespace Rivoltante.Core;

public interface IUserStatus
{
    string? Text { get; }
    
    UserPresence? Presence { get; }
}