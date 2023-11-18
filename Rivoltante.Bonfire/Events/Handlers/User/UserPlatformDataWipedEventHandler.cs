using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class UserPlatformDataWipedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<UserPlatformWipeEventApiModel, UserPlatformDataWipedEventArgs>(eventManager)
{
    public override ValueTask<UserPlatformDataWipedEventArgs?> HandleAsync(IBonfireClient client, UserPlatformWipeEventApiModel model)
    {
        var e = new UserPlatformDataWipedEventArgs(model.UserId, Enum.TryParse(model.Flags, out UserFlag flags)
            ? flags
            : default);

        return new(e);
    }
}