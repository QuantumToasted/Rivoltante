namespace Rivoltante.Bonfire;

public class IncomingEventReceivedEventArgs(IncomingEventApiModel model) : EventArgs
{
    public IncomingEventApiModel Model { get; } = model;

    public IncomingEventType? Type { get; } = model.Type;
}