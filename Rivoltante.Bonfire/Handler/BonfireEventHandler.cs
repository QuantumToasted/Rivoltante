using System.Collections.Concurrent;
using System.Reflection;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public abstract class BonfireEventHandler(RevoltBonfireEventManager eventManager)
{
    private protected static readonly ConcurrentDictionary<RevoltBonfireEventManager, Dictionary<Type, IAsyncEvent>> EventManagers = new();
    private protected static readonly PropertyInfo[] EventProperties;
    
    public RevoltBonfireEventManager EventManager { get; } = eventManager;

    public abstract ValueTask HandleEventAsync(IRevoltClient client, IncomingEventApiModel model);

    static BonfireEventHandler()
    {
        EventProperties = typeof(RevoltBonfireEventManager).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(AsyncEvent<>))
            .ToArray();
    }
}

public abstract class BonfireEventHandler<TEventArgs> : BonfireEventHandler
    where TEventArgs : EventArgs
{
    private protected readonly AsyncEvent<TEventArgs> _event;
    private protected readonly Dictionary<Type, IAsyncEvent> _events;

    protected BonfireEventHandler(RevoltBonfireEventManager eventManager)
        : base(eventManager)
    {
        _events = EventManagers.GetOrAdd(eventManager, em =>
        {
            var dict = new Dictionary<Type, IAsyncEvent>(EventProperties.Length);
            foreach (var property in EventProperties)
            {
                dict.Add(property.PropertyType.GenericTypeArguments[0], (IAsyncEvent) property.GetValue(em)!);
            }

            return dict;
        });

        if (!_events.TryGetValue(typeof(TEventArgs), out var @event))
            throw new ArgumentException($"No {nameof(RevoltBonfireEventManager)} even was found with event type {nameof(TEventArgs)}.");

        _event = (AsyncEvent<TEventArgs>) @event;
    }
}

public abstract class BonfireEventHandler<TModel, TEventArgs>(RevoltBonfireEventManager eventManager) : BonfireEventHandler<TEventArgs>(eventManager)
    where TModel : IncomingEventApiModel
    where TEventArgs : EventArgs
{
    public override async ValueTask HandleEventAsync(IRevoltClient client, IncomingEventApiModel model)
    {
        var eventModel = (TModel) model;
        var e = await HandleEventAsync(client, eventModel).ConfigureAwait(false);

        if (e is null)
            return;

        await InvokeEventAsync(e).ConfigureAwait(false);
    }

    public ValueTask InvokeEventAsync(TEventArgs e)
    {
        _ = _event.InvokeAsync(EventManager, e, AsyncEventInvocationMode.Concurrent).AsTask(); // TODO: When is Consecutive used?
        return ValueTask.CompletedTask;
    }

    protected abstract ValueTask<TEventArgs?> HandleEventAsync(IRevoltClient client, TModel model);
}