namespace Rivoltante.Bonfire;

public partial interface IBonfireEventManager
{
    AsyncEvent<ErrorEventArgs> ErrorEvent { get; }
    
    AsyncEvent<AuthenticatedEventArgs> AuthenticatedEvent { get; }
    
    AsyncEvent<PongEventArgs> PongEvent { get; }
    
    AsyncEvent<ReadyEventArgs> ReadyEvent { get; }
    
    AsyncEvent<MessageCreatedEventArgs> MessageCreatedEvent { get; }
    
    AsyncEvent<MessageUpdatedEventArgs> MessageUpdatedEvent { get; }
    
    AsyncEvent<MessageDeletedEventArgs> MessageDeletedEvent { get; }
    
    AsyncEvent<MessageReactedEventArgs> MessageReactedEvent { get; }
    
    AsyncEvent<MessageUnreactedEventArgs> MessageUnreactedEvent { get; }
    
    AsyncEvent<MessageReactionRemovedEventArgs> ReactionRemovedEvent { get; }
    
    AsyncEvent<ChannelCreatedEventArgs> ChannelCreatedEvent { get; }
    
    AsyncEvent<ChannelUpdatedEventArgs> ChannelUpdatedEvent { get; }
    
    AsyncEvent<ChannelDeletedEventArgs> ChannelDeletedEvent { get; }
    
    AsyncEvent<ChannelGroupJoinedEventArgs> GroupJoinedEvent { get; }
    
    AsyncEvent<ChannelGroupLeftEventArgs> GroupLeftEvent { get; }
    
    AsyncEvent<ChannelTypingStartedEventArgs> TypingStartedEvent { get; }
    
    AsyncEvent<ChannelTypingStoppedEventArgs> TypingStoppedEvent { get; }
    
    AsyncEvent<MessagesAcknowledgedEventArgs> MessagesAcknowledgedEvent { get; }
    
    AsyncEvent<ServerCreatedEventArgs> ServerCreatedEvent { get; }
    
    AsyncEvent<ServerUpdatedEventArgs> ServerUpdatedEvent { get; }
    
    AsyncEvent<ServerDeletedEventArgs> ServerDeletedEvent { get; }
    
    AsyncEvent<ServerMemberUpdatedEventArgs> MemberUpdatedEvent { get; }
    
    AsyncEvent<ServerMemberJoinedEventArgs> MemberJoinedEvent { get; }
    
    AsyncEvent<ServerMemberLeftEventArgs> MemberLeftEvent { get; }
    
    AsyncEvent<ServerRoleUpdatedEventArgs> RoleUpdatedEvent { get; }
    
    AsyncEvent<ServerRoleDeletedEventArgs> RoleDeletedEvent { get; }
    
    AsyncEvent<UserUpdatedEventArgs> UserUpdatedEvent { get; }
    
    AsyncEvent<UserRelationshipUpdatedEventArgs> UserRelationshipUpdatedEvent { get; }
    
    AsyncEvent<UserPlatformDataWipedEventArgs> UserPlatformDataWipedEvent { get; }
    
    AsyncEvent<EmojiCreatedEventArgs> EmojiCreatedEvent { get; }
    
    AsyncEvent<EmojiDeletedEventArgs> EmojiDeletedEvent { get; }
}