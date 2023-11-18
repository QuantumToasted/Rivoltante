namespace Rivoltante.Core;

public sealed class UserProfileApiModel : IApiModel
{
    public Optional<string> Content { get; init; }

    public Optional<AttachmentApiModel> Background { get; init; }
}