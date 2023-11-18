namespace Rivoltante.Core;

public sealed class UserBotInformationApiModel : IApiModel
{
    public required Ulid Owner { get; init; }
}