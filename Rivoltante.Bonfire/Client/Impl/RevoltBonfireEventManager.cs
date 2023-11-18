using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed partial class RevoltBonfireEventManager : IBonfireEventManager
{
    private readonly ConcurrentDictionary<ReceiveEventType, BonfireEventHandler> _handlers;
    private bool _initialized;

    public RevoltBonfireEventManager(ILogger<RevoltBonfireEventManager> logger)
    {
        Logger = logger;

        var handlers = new Dictionary<ReceiveEventType, BonfireEventHandler>
        {
            [ReceiveEventType.Error] = new ErrorEventHandler(this),
            [ReceiveEventType.Authenticated] = new AuthenticatedEventHandler(this),
            //[ReceiveEventType.Bulk] = 
            [ReceiveEventType.Pong] = new PongEventHandler(this),
            [ReceiveEventType.Ready] = new ReadyEventHandler(this),
            [ReceiveEventType.Message] = new MessageCreatedEventHandler(this),
            [ReceiveEventType.MessageUpdate] = new MessageUpdatedEventHandler(this),
            [ReceiveEventType.MessageAppend] = new MessageUpdatedEventHandler(this), // TODO: issues with two events mapping to the same handler?
            [ReceiveEventType.MessageDelete] = new MessageDeletedEventHandler(this),
            [ReceiveEventType.MessageReact] = new MessageReactedEventHandler(this),
            [ReceiveEventType.MessageUnreact] = new MessageUnreactedEventHandler(this),
            [ReceiveEventType.MessageRemoveReaction] = new MessageReactionRemovedEventHandler(this),
            [ReceiveEventType.ChannelCreate] = new ChannelCreatedEventHandler(this),
            [ReceiveEventType.ChannelUpdate] = new ChannelUpdatedEventHandler(this),
            [ReceiveEventType.ChannelDelete] = new ChannelDeletedEventHandler(this),
            [ReceiveEventType.ChannelGroupJoin] = new ChannelGroupJoinedEventHandler(this),
            [ReceiveEventType.ChannelGroupLeave] = new ChannelGroupLeftEventHandler(this),
            [ReceiveEventType.ChannelStartTyping] = new ChannelTypingStartedEventHandler(this),
            [ReceiveEventType.ChannelStopTyping] = new ChannelTypingStoppedEventHandler(this),
            [ReceiveEventType.ChannelAck] = new MessagesAcknowledgedEventHandler(this),
            [ReceiveEventType.ServerCreate] = new ServerCreatedEventHandler(this),
            [ReceiveEventType.ServerUpdate] = new ServerUpdatedEventHandler(this),
            [ReceiveEventType.ServerDelete] = new ServerDeletedEventHandler(this),
            [ReceiveEventType.ServerMemberUpdate] = new ServerMemberUpdatedEventHandler(this),
            [ReceiveEventType.ServerMemberJoin] = new ServerMemberJoinedEventHandler(this),
            [ReceiveEventType.ServerMemberLeave] = new ServerMemberLeftEventHandler(this),
            [ReceiveEventType.ServerRoleUpdate] = new ServerRoleUpdatedEventHandler(this),
            [ReceiveEventType.ServerRoleDelete] = new ServerRoleDeletedEventHandler(this),
            [ReceiveEventType.UserUpdate] = new UserUpdatedEventHandler(this),
            [ReceiveEventType.UserRelationship] = new UserRelationshipUpdatedEventHandler(this),
            [ReceiveEventType.UserPlatformWipe] = new UserPlatformDataWipedEventHandler(this),
            [ReceiveEventType.EmojiCreate] = new EmojiCreatedEventHandler(this),
            [ReceiveEventType.EmojiDelete] = new EmojiDeletedEventHandler(this) 
        };

        _handlers = new ConcurrentDictionary<ReceiveEventType, BonfireEventHandler>(handlers);
    }
    
    public ILogger Logger { get; }

    public IBonfireClient Client { get; private set; } = null!;
    
    public void Initialize(IBonfireClient client)
    {
        if (_initialized) 
            return;

        Client = client;
        client.ApiClient.ReceivedEvent.Add(HandleDispatchAsync);
        _initialized = true;
    }

    public async ValueTask HandleDispatchAsync(object? sender, BonfireReceivedEventArgs e)
    {
        Ensure.Is<IBonfireApiClient>(sender);
        
        Logger.LogInformation("Received event {Type}", e.Type);

        if (e.Model is BulkEventApiModel bulkEventApiModel)
        {
            foreach (var model in bulkEventApiModel.V)
            {
                await HandleAsync(Client, model).ConfigureAwait(false);
            }

            return;
        }

        await HandleAsync(Client, e.Model).ConfigureAwait(false);
    }

    private async ValueTask HandleAsync(IBonfireClient client, IReceiveEventApiModel model)
    {
        if (!model.Type.HasValue || !_handlers.TryGetValue(model.Type.Value, out var handler))
        {
            Logger.LogWarning("Encountered an unknown Bonfire event, or a handler has not been registered for this event type {Type}.", model.Type);
            return;
        }

        try
        {
            await handler.HandleAsync(Client, model).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred handling the Bonfire event {EventType}.\n{Json}", model.Type.Value,
                JsonSerializer.Serialize(model, Client.ApiClient.SerializerOptions));
        }
    }
}