namespace Rivoltante.Bonfire;

public sealed class BonfireReceivedEventArgs(IReceiveEventApiModel model) : EventArgs
{
    public IReceiveEventApiModel Model { get; } = model;

    public ReceiveEventType? Type => Model.Type;
}