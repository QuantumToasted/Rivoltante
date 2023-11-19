using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class SetGroupChannelDefaultPermissionsRequestApiModel : IApiModel
{
    public required Permission Permissions { get; init; }
}