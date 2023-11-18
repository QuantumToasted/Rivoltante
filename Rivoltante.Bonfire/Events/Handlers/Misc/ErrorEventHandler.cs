namespace Rivoltante.Bonfire;

public sealed class ErrorEventHandler(RevoltBonfireEventManager eventManager) : BonfireEventHandler<ErrorEventApiModel, ErrorEventArgs>(eventManager)
{
    public override ValueTask<ErrorEventArgs?> HandleAsync(IBonfireClient client, ErrorEventApiModel model)
    {
        var e = new ErrorEventArgs(model.Error);
        return new(e);
    }
}