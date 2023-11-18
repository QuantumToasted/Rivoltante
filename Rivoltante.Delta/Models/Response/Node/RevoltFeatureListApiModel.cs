using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class RevoltFeatureListApiModel : IApiModel
{
    public required RevoltFeatureApiModel Captcha { get; init; }

    public required bool Email { get; init; }

    public required bool InviteOnly { get; init; }

    public required RevoltFeatureApiModel Autumn { get; init; }

    public required RevoltFeatureApiModel January { get; init; }

    public required RevoltFeatureApiModel Voso { get; init; }
}