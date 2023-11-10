namespace Rivoltante.Core;

public sealed class CommonServerInvite(InviteApiModel model, IRevoltClient client) : CommonInvite(model, client), IServerInvite
{
    public Ulid ServerId { get; } = model.Server.Value;
}