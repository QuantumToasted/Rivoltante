using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class PartialServerMemberUpdateApiModel : IApiModel
{
    public Optional<string> Nickname { get; init; }

    public Optional<AttachmentApiModel> Avatar { get; init; }
    
    public Optional<Ulid[]> Roles { get; init; }

    public Optional<DateTimeOffset> Timeout { get; init; }
}