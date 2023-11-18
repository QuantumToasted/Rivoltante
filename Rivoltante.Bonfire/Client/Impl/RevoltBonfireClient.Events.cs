namespace Rivoltante.Bonfire;

public sealed partial class RevoltBonfireClient
{
    public event AsyncEventHandler<ErrorEventArgs> Error
    {
        add => EventManager.ErrorEvent.Add(value);
        remove => EventManager.ErrorEvent.Remove(value);
    }
    
    public event AsyncEventHandler<AuthenticatedEventArgs> Authenticated
    {
        add => EventManager.AuthenticatedEvent.Add(value);
        remove => EventManager.AuthenticatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<PongEventArgs> Pong
    {
        add => EventManager.PongEvent.Add(value);
        remove => EventManager.PongEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ReadyEventArgs> Ready
    {
        add => EventManager.ReadyEvent.Add(value);
        remove => EventManager.ReadyEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageCreatedEventArgs> MessageCreated
    {
        add => EventManager.MessageCreatedEvent.Add(value);
        remove => EventManager.MessageCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageUpdatedEventArgs> MessageUpdated
    {
        add => EventManager.MessageUpdatedEvent.Add(value);
        remove => EventManager.MessageUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageDeletedEventArgs> MessageDeleted
    {
        add => EventManager.MessageDeletedEvent.Add(value);
        remove => EventManager.MessageDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageReactedEventArgs> MessageReacted
    {
        add => EventManager.MessageReactedEvent.Add(value);
        remove => EventManager.MessageReactedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageUnreactedEventArgs> MessageUnreacted
    {
        add => EventManager.MessageUnreactedEvent.Add(value);
        remove => EventManager.MessageUnreactedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageReactionRemovedEventArgs> ReactionRemoved
    {
        add => EventManager.ReactionRemovedEvent.Add(value);
        remove => EventManager.ReactionRemovedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelCreatedEventArgs> ChannelCreated
    {
        add => EventManager.ChannelCreatedEvent.Add(value);
        remove => EventManager.ChannelCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelUpdatedEventArgs> ChannelUpdated
    {
        add => EventManager.ChannelUpdatedEvent.Add(value);
        remove => EventManager.ChannelUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelDeletedEventArgs> ChannelDeleted
    {
        add => EventManager.ChannelDeletedEvent.Add(value);
        remove => EventManager.ChannelDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelGroupJoinedEventArgs> GroupJoined
    {
        add => EventManager.GroupJoinedEvent.Add(value);
        remove => EventManager.GroupJoinedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelGroupLeftEventArgs> GroupLeft
    {
        add => EventManager.GroupLeftEvent.Add(value);
        remove => EventManager.GroupLeftEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelTypingStartedEventArgs> TypingStarted
    {
        add => EventManager.TypingStartedEvent.Add(value);
        remove => EventManager.TypingStartedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelTypingStoppedEventArgs> TypingStopped
    {
        add => EventManager.TypingStoppedEvent.Add(value);
        remove => EventManager.TypingStoppedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessagesAcknowledgedEventArgs> MessagesAcknowledged
    {
        add => EventManager.MessagesAcknowledgedEvent.Add(value);
        remove => EventManager.MessagesAcknowledgedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerCreatedEventArgs> ServerCreated
    {
        add => EventManager.ServerCreatedEvent.Add(value);
        remove => EventManager.ServerCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerUpdatedEventArgs> ServerUpdated
    {
        add => EventManager.ServerUpdatedEvent.Add(value);
        remove => EventManager.ServerUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerDeletedEventArgs> ServerDeleted
    {
        add => EventManager.ServerDeletedEvent.Add(value);
        remove => EventManager.ServerDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerMemberUpdatedEventArgs> MemberUpdated
    {
        add => EventManager.MemberUpdatedEvent.Add(value);
        remove => EventManager.MemberUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerMemberJoinedEventArgs> MemberJoined
    {
        add => EventManager.MemberJoinedEvent.Add(value);
        remove => EventManager.MemberJoinedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerMemberLeftEventArgs> MemberLeft
    {
        add => EventManager.MemberLeftEvent.Add(value);
        remove => EventManager.MemberLeftEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerRoleUpdatedEventArgs> RoleUpdated
    {
        add => EventManager.RoleUpdatedEvent.Add(value);
        remove => EventManager.RoleUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerRoleDeletedEventArgs> RoleDeleted
    {
        add => EventManager.RoleDeletedEvent.Add(value);
        remove => EventManager.RoleDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<UserUpdatedEventArgs> UserUpdated
    {
        add => EventManager.UserUpdatedEvent.Add(value);
        remove => EventManager.UserUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<UserRelationshipUpdatedEventArgs> UserRelationshipUpdated
    {
        add => EventManager.UserRelationshipUpdatedEvent.Add(value);
        remove => EventManager.UserRelationshipUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<UserPlatformDataWipedEventArgs> UserPlatformDataWiped
    {
        add => EventManager.UserPlatformDataWipedEvent.Add(value);
        remove => EventManager.UserPlatformDataWipedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<EmojiCreatedEventArgs> EmojiCreated
    {
        add => EventManager.EmojiCreatedEvent.Add(value);
        remove => EventManager.EmojiCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<EmojiDeletedEventArgs> EmojiDeleted
    {
        add => EventManager.EmojiDeletedEvent.Add(value);
        remove => EventManager.EmojiDeletedEvent.Remove(value);
    }
}