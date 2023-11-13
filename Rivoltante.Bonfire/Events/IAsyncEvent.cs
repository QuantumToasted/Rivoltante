namespace Rivoltante.Bonfire;

public interface IAsyncEvent
{
    ValueTask InvokeAsync(object? sender, EventArgs e, AsyncEventInvocationMode invocationMode);
}

public interface IAsyncEvent<in TEventArgs> : IAsyncEvent
    where TEventArgs : EventArgs
{
    ValueTask InvokeAsync(object? sender, TEventArgs e, AsyncEventInvocationMode invocationMode);

    ValueTask IAsyncEvent.InvokeAsync(object? sender, EventArgs e, AsyncEventInvocationMode invocationMode)
        => InvokeAsync(sender, (TEventArgs)e, invocationMode);
}