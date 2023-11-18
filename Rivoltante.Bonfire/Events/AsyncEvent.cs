using System.Collections.Immutable;

namespace Rivoltante.Bonfire;

public delegate ValueTask AsyncEventHandler<in TEventArgs>(object? sender, TEventArgs e)
    where TEventArgs : EventArgs;

public sealed class AsyncEvent<TEventArgs> : IAsyncEvent<TEventArgs>
    where TEventArgs : EventArgs
{
    private ImmutableHashSet<AsyncEventHandler<TEventArgs>> _handlers = ImmutableHashSet<AsyncEventHandler<TEventArgs>>.Empty;

    public void Add(AsyncEventHandler<TEventArgs> handler)
    {
        if (!ImmutableInterlocked.Update(ref _handlers, static (handlers, handler) => handlers.Add(handler), handler))
            throw new InvalidOperationException($"Async event handler {handler} is already subscribed to this event.");
    }

    public void Remove(AsyncEventHandler<TEventArgs> handler)
    {
        if (!ImmutableInterlocked.Update(ref _handlers, static (handlers, handler) => handlers.Remove(handler), handler))
            throw new InvalidOperationException($"Async event handler {handler} is not subscribed to this event.");
    }

    public void Clear()
        => ImmutableInterlocked.Update(ref _handlers, static handlers => handlers.Clear());

    public async ValueTask InvokeAsync(object? sender, TEventArgs e)
    {
        var exceptions = new List<Exception>();
        var tasks = new List<ValueTask?>(_handlers.Count);

        foreach (var handler in _handlers)
        {
            try
            {
                tasks.Add(handler.Invoke(sender, e));
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
        }

        foreach (var task in tasks)
        {
            if (!task.HasValue)
                continue;

            try
            {
                await task.Value.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
        }

        if (exceptions.Count > 0)
            throw new AggregateException("One or more exceptions occured during event invocation.", exceptions);
    }
}