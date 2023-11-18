namespace Rivoltante.Bonfire;

public partial interface IBonfireClient
{
    event AsyncEventHandler<ErrorEventArgs> ErrorEvent;
    
    event AsyncEventHandler<AuthenticatedEventArgs> AuthenticatedEvent;
    
    event AsyncEventHandler<PongEventArgs> PongEvent;
    
    event AsyncEventHandler<ReadyEventArgs> ReadyEvent;
    
    event AsyncEventHandler<MessageCreatedEventArgs> MessageCreatedEvent;
    
    event AsyncEventHandler<MessageUpdatedEventArgs> MessageUpdatedEvent;
    
    event AsyncEventHandler<MessageDeletedEventArgs> MessageDeletedEvent;
    
    event AsyncEventHandler<MessageReactedEventArgs> MessageReactedEvent;
    
    event AsyncEventHandler<MessageUnreactedEventArgs> MessageUnreactedEvent;
    
    event AsyncEventHandler<MessageReactionRemovedEventArgs> ReactionRemovedEvent;
    
    event AsyncEventHandler<ChannelCreatedEventArgs> ChannelCreatedEvent;
    
    event AsyncEventHandler<ChannelUpdatedEventArgs> ChannelUpdatedEvent;
    
    event AsyncEventHandler<ChannelDeletedEventArgs> ChannelDeletedEvent;
    
    event AsyncEventHandler<ChannelGroupJoinedEventArgs> GroupJoinedEvent;
    
    event AsyncEventHandler<ChannelGroupLeftEventArgs> GroupLeftEvent;
    
    event AsyncEventHandler<ChannelTypingStartedEventArgs> TypingStartedEvent;
    
    event AsyncEventHandler<ChannelTypingStoppedEventArgs> TypingStoppedEvent;
    
    event AsyncEventHandler<MessagesAcknowledgedEventArgs> MessagesAcknowledgedEvent;
    
    event AsyncEventHandler<ServerCreatedEventArgs> ServerCreatedEvent;
    
    event AsyncEventHandler<ServerUpdatedEventArgs> ServerUpdatedEvent;
    
    event AsyncEventHandler<ServerDeletedEventArgs> ServerDeletedEvent;
    
    event AsyncEventHandler<ServerMemberUpdatedEventArgs> MemberUpdatedEvent;
    
    event AsyncEventHandler<ServerMemberJoinedEventArgs> MemberJoinedEvent;
    
    event AsyncEventHandler<ServerMemberLeftEventArgs> MemberLeftEvent;
    
    event AsyncEventHandler<ServerRoleUpdatedEventArgs> RoleUpdatedEvent;
    
    event AsyncEventHandler<ServerRoleDeletedEventArgs> RoleDeletedEvent;
    
    event AsyncEventHandler<UserUpdatedEventArgs> UserUpdatedEvent;
    
    event AsyncEventHandler<UserRelationshipUpdatedEventArgs> UserRelationshipUpdatedEvent;
    
    event AsyncEventHandler<UserPlatformDataWipedEventArgs> UserPlatformDataWipedEvent;
    
    event AsyncEventHandler<EmojiCreatedEventArgs> EmojiCreatedEvent;
    
    event AsyncEventHandler<EmojiDeletedEventArgs> EmojiDeletedEvent;
}