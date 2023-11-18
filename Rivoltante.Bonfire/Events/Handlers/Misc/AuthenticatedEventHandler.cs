namespace Rivoltante.Bonfire;

public sealed class AuthenticatedEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<AuthenticatedEventApiModel, AuthenticatedEventArgs>(eventManager)
{
    public override ValueTask<AuthenticatedEventArgs?> HandleAsync(IBonfireClient client, AuthenticatedEventApiModel model)
    {
        var e = new AuthenticatedEventArgs();
        return new(e);
    }
}