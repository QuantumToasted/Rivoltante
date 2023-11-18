namespace Rivoltante.Bonfire;

public sealed partial class RevoltBonfireClient
{
    public event AsyncEventHandler<ErrorEventArgs> ErrorEvent
    {
        add => EventManager.ErrorEvent.Add(value);
        remove => EventManager.ErrorEvent.Remove(value);
    }
    
    public event AsyncEventHandler<AuthenticatedEventArgs> AuthenticatedEvent
    {
        add => EventManager.AuthenticatedEvent.Add(value);
        remove => EventManager.AuthenticatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<PongEventArgs> PongEvent
    {
        add => EventManager.PongEvent.Add(value);
        remove => EventManager.PongEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ReadyEventArgs> ReadyEvent
    {
        add => EventManager.ReadyEvent.Add(value);
        remove => EventManager.ReadyEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageCreatedEventArgs> MessageCreatedEvent
    {
        add => EventManager.MessageCreatedEvent.Add(value);
        remove => EventManager.MessageCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageUpdatedEventArgs> MessageUpdatedEvent
    {
        add => EventManager.MessageUpdatedEvent.Add(value);
        remove => EventManager.MessageUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageDeletedEventArgs> MessageDeletedEvent
    {
        add => EventManager.MessageDeletedEvent.Add(value);
        remove => EventManager.MessageDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageReactedEventArgs> MessageReactedEvent
    {
        add => EventManager.MessageReactedEvent.Add(value);
        remove => EventManager.MessageReactedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageUnreactedEventArgs> MessageUnreactedEvent
    {
        add => EventManager.MessageUnreactedEvent.Add(value);
        remove => EventManager.MessageUnreactedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessageReactionRemovedEventArgs> ReactionRemovedEvent
    {
        add => EventManager.ReactionRemovedEvent.Add(value);
        remove => EventManager.ReactionRemovedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelCreatedEventArgs> ChannelCreatedEvent
    {
        add => EventManager.ChannelCreatedEvent.Add(value);
        remove => EventManager.ChannelCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelUpdatedEventArgs> ChannelUpdatedEvent
    {
        add => EventManager.ChannelUpdatedEvent.Add(value);
        remove => EventManager.ChannelUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelDeletedEventArgs> ChannelDeletedEvent
    {
        add => EventManager.ChannelDeletedEvent.Add(value);
        remove => EventManager.ChannelDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelGroupJoinedEventArgs> GroupJoinedEvent
    {
        add => EventManager.GroupJoinedEvent.Add(value);
        remove => EventManager.GroupJoinedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelGroupLeftEventArgs> GroupLeftEvent
    {
        add => EventManager.GroupLeftEvent.Add(value);
        remove => EventManager.GroupLeftEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelTypingStartedEventArgs> TypingStartedEvent
    {
        add => EventManager.TypingStartedEvent.Add(value);
        remove => EventManager.TypingStartedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ChannelTypingStoppedEventArgs> TypingStoppedEvent
    {
        add => EventManager.TypingStoppedEvent.Add(value);
        remove => EventManager.TypingStoppedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<MessagesAcknowledgedEventArgs> MessagesAcknowledgedEvent
    {
        add => EventManager.MessagesAcknowledgedEvent.Add(value);
        remove => EventManager.MessagesAcknowledgedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerCreatedEventArgs> ServerCreatedEvent
    {
        add => EventManager.ServerCreatedEvent.Add(value);
        remove => EventManager.ServerCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerUpdatedEventArgs> ServerUpdatedEvent
    {
        add => EventManager.ServerUpdatedEvent.Add(value);
        remove => EventManager.ServerUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerDeletedEventArgs> ServerDeletedEvent
    {
        add => EventManager.ServerDeletedEvent.Add(value);
        remove => EventManager.ServerDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerMemberUpdatedEventArgs> MemberUpdatedEvent
    {
        add => EventManager.MemberUpdatedEvent.Add(value);
        remove => EventManager.MemberUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerMemberJoinedEventArgs> MemberJoinedEvent
    {
        add => EventManager.MemberJoinedEvent.Add(value);
        remove => EventManager.MemberJoinedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerMemberLeftEventArgs> MemberLeftEvent
    {
        add => EventManager.MemberLeftEvent.Add(value);
        remove => EventManager.MemberLeftEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerRoleUpdatedEventArgs> RoleUpdatedEvent
    {
        add => EventManager.RoleUpdatedEvent.Add(value);
        remove => EventManager.RoleUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<ServerRoleDeletedEventArgs> RoleDeletedEvent
    {
        add => EventManager.RoleDeletedEvent.Add(value);
        remove => EventManager.RoleDeletedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<UserUpdatedEventArgs> UserUpdatedEvent
    {
        add => EventManager.UserUpdatedEvent.Add(value);
        remove => EventManager.UserUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<UserRelationshipUpdatedEventArgs> UserRelationshipUpdatedEvent
    {
        add => EventManager.UserRelationshipUpdatedEvent.Add(value);
        remove => EventManager.UserRelationshipUpdatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<UserPlatformDataWipedEventArgs> UserPlatformDataWipedEvent
    {
        add => EventManager.UserPlatformDataWipedEvent.Add(value);
        remove => EventManager.UserPlatformDataWipedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<EmojiCreatedEventArgs> EmojiCreatedEvent
    {
        add => EventManager.EmojiCreatedEvent.Add(value);
        remove => EventManager.EmojiCreatedEvent.Remove(value);
    }
    
    public event AsyncEventHandler<EmojiDeletedEventArgs> EmojiDeletedEvent
    {
        add => EventManager.EmojiDeletedEvent.Add(value);
        remove => EventManager.EmojiDeletedEvent.Remove(value);
    }
}