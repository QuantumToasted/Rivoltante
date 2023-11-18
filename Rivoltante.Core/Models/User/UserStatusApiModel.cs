namespace Rivoltante.Core;

public sealed class UserStatusApiModel : IApiModel
{
    public Optional<string> Text { get; init; }
    
    public Optional<UserPresence> Presence { get; init; }
}