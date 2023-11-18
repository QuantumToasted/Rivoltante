namespace Rivoltante.Bonfire;

public interface IAsyncEvent
{
    ValueTask InvokeAsync(object? sender, EventArgs e);
}

public interface IAsyncEvent<in TEventArgs> : IAsyncEvent
    where TEventArgs : EventArgs
{
    ValueTask InvokeAsync(object? sender, TEventArgs e);

    ValueTask IAsyncEvent.InvokeAsync(object? sender, EventArgs e)
        => InvokeAsync(sender, (TEventArgs)e);
}