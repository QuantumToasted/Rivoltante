namespace Rivoltante.Core;

public sealed class CommonUnknownInvite(InviteApiModel model, IRevoltClient client) : CommonInvite(model, client), IUnknownInvite;