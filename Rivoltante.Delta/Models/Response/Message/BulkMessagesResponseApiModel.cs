using Rivoltante.Core;

namespace Rivoltante.Delta;

// TODO: Formerly FetchMessageWithUsersApiModel - this model is returned internally even if users are not included for simplicity
public sealed class BulkMessagesResponseApiModel : IApiModel
{
    public required MessageApiModel[] Messages { get; init; }

    public Optional<UserApiModel[]> Users { get; init; }

    public Optional<MemberApiModel[]> Members { get; init; }
}