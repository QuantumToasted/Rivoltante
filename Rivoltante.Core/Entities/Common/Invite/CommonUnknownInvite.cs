namespace Rivoltante.Core;

public sealed class CommonUnknownInvite(InviteApiModel model, IRevoltClient client) : CommonInvite(model, client), IUnknownInvite
{
    public string RawInviteType { get; } = model.Type;
    
    public override InviteType Type => throw new InvalidOperationException("Unknown invite type.");
}