using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Rivoltante.Bonfire;

public abstract class BonfireEventHandler<TModel, TEventArgs> : BonfireEventHandler
    where TModel : IReceiveEventApiModel
    where TEventArgs : EventArgs
{
    private readonly AsyncEvent<TEventArgs> _event;
    
    protected BonfireEventHandler(RevoltBonfireEventManager eventManager)
        : base(eventManager)
    {
        var events = EventManagers.GetOrAdd(eventManager, static manager =>
        {
            var dict = new Dictionary<Type, IAsyncEvent>(EventProperties.Length);

            foreach (var property in EventProperties)
            {
                dict.Add(property.PropertyType.GenericTypeArguments[0], (IAsyncEvent) property.GetValue(manager)!);
            }

            return dict;
        });
        
        if (!events.TryGetValue(typeof(TEventArgs), out var @event))
            throw new ArgumentException($"No {nameof(RevoltBonfireEventManager)} event found matching the event args type {typeof(TEventArgs).Name}.");

        _event = (AsyncEvent<TEventArgs>) @event;
    }
    
    public abstract ValueTask<TEventArgs?> HandleAsync(IBonfireClient client, TModel model);
    
    public sealed override async ValueTask HandleAsync(IBonfireClient client, IReceiveEventApiModel model)
    {
        var e = await HandleAsync(client, (TModel)model).ConfigureAwait(false);
        if (e is null)
            return;

        _ = _event.InvokeAsync(EventManager, e).AsTask();
    }
}

public abstract class BonfireEventHandler(RevoltBonfireEventManager eventManager)
{
    private protected static readonly ConcurrentDictionary<RevoltBonfireEventManager, Dictionary<Type, IAsyncEvent>> EventManagers = new();
    private protected static readonly PropertyInfo[] EventProperties;
    
    public RevoltBonfireEventManager EventManager { get; } = eventManager;

    public ILogger Logger => EventManager.Logger;

    public abstract ValueTask HandleAsync(IBonfireClient client, IReceiveEventApiModel model);

    static BonfireEventHandler()
    {
        EventProperties = typeof(RevoltBonfireEventManager).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(AsyncEvent<>))
            .ToArray();
    }
}