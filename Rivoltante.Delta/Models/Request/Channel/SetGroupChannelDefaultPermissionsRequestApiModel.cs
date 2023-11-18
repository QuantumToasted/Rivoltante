using Rivoltante.Core;

namespace Rivoltante.Delta;

public class SetGroupChannelDefaultPermissionsRequestApiModel : IApiModel
{
    public required Permission Permissions { get; init; }
}