namespace Rivoltante.Core;

public sealed class CommonGroupInvite(InviteApiModel model, IRevoltClient client) : CommonInvite(model, client), IGroupInvite
{
    public override InviteType Type => InviteType.Group;
}