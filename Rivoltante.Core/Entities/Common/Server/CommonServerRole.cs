namespace Rivoltante.Core;

public sealed class CommonServerRole(Ulid serverId, Ulid id, ServerRoleApiModel model, IRevoltClient client) : IServerRole
{
    public IRevoltClient Client { get; } = client;

    public Ulid ServerId { get; } = serverId;

    public Ulid Id { get; } = id;

    public string Name { get; } = model.Name;

    public IPermissions Permissions { get; } = new CommonPermissions(model.Permissions);

    public string? Color { get; } = model.Color.GetValueOrDefault();

    public bool IsHoisted { get; } = model.Hoist.GetValueOrDefault();

    public long Rank { get; } = model.Rank;
}