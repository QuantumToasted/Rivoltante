namespace Rivoltante.Core;

public sealed class CommonMember(UserApiModel model, MemberApiModel memberModel, IRevoltClient client) : CommonUser(model, client), IMember
{
    public Ulid ServerId { get; } = memberModel.Id.Server;

    public DateTimeOffset JoinedAt { get; } = memberModel.JoinedAt;

    public string? Nickname { get; } = memberModel.Nickname.GetValueOrDefault();

    public IAttachment? ServerAvatar { get; } = Optional<IAttachment>.ConvertOrDefault(memberModel.Avatar, x => new CommonAttachment(x));

    public IReadOnlyList<Ulid> RoleIds { get; } = Optional<IReadOnlyList<Ulid>>.ConvertOrFallback(memberModel.Roles, x => x.ToList(), new List<Ulid>());

    public DateTimeOffset? TimedOutUntil { get; } = memberModel.Timeout.GetValueOrNullable();
}