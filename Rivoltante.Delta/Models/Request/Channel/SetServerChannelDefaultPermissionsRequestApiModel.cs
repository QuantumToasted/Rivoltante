using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class SetServerChannelDefaultPermissionsRequestApiModel : IApiModel
{
    public required PermissionsApiModel Permissions { get; init; }
}