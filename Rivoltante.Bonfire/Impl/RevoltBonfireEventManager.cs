using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Rivoltante.Bonfire.Message;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class RevoltBonfireEventManager : IBonfireEventManager
{
    private readonly ConcurrentDictionary<IncomingEventType, BonfireEventHandler> _handlers;
    private readonly HashSet<IncomingEventType> _unknownEvents = new();

    public RevoltBonfireEventManager(ILogger<RevoltBonfireEventManager> logger, IBonfireClient client)
    {
        Logger = logger;
        Client = client;

        var handlers = new Dictionary<IncomingEventType, BonfireEventHandler>
        {
            [IncomingEventType.Message] = new MessageEventHandler(this)
        };

        _handlers = new ConcurrentDictionary<IncomingEventType, BonfireEventHandler>(handlers);
    }
    
    public ILogger Logger { get; }
    
    public IBonfireClient Client { get; }
    
    public async ValueTask HandleDispatchAsync(object? sender, IncomingEventReceivedEventArgs e)
    {
        if (sender is not IRevoltClient client)
            throw new ArgumentException($"The sender is expected to be a '{typeof(IRevoltClient)}' instance.", nameof(sender));

        if (!e.Type.HasValue)
            return; // TODO: special case?

        if (!_handlers.TryGetValue(e.Type.Value, out var handler))
        {
            if (!_unknownEvents.Add(e.Type.Value))
                return;
            
            Logger.LogWarning("Received an unimplemented event type {Type}.", e.Type.Value);
            return;
        }

        try
        {
            await handler.HandleEventAsync(client, e.Model).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occured while handling event {Type}.", e.Type.Value);
        }
    }
}