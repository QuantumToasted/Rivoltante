namespace Rivoltante.Core;

public class ServerSystemMessagesApiModel : IApiModel
{
    public Optional<Ulid> UserJoined { get; init; }

    public Optional<Ulid> UserLeft { get; init; }

    public Optional<Ulid> UserKicked { get; init; }

    public Optional<Ulid> UserBanned { get; init; }

}