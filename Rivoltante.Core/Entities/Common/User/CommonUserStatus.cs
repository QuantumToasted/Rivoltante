namespace Rivoltante.Core;

public sealed class CommonUserStatus(UserStatusApiModel model) : IUserStatus
{
    public string? Text { get; } = model.Text.GetValueOrDefault();

    public UserPresence? Presence { get; } = model.Presence.GetValueOrDefault();
}