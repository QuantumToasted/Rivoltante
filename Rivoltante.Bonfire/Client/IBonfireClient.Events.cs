namespace Rivoltante.Bonfire;

public partial interface IBonfireClient
{
    event AsyncEventHandler<ErrorEventArgs> Error;
    
    event AsyncEventHandler<AuthenticatedEventArgs> Authenticated;
    
    event AsyncEventHandler<PongEventArgs> Pong;
    
    event AsyncEventHandler<ReadyEventArgs> Ready;
    
    event AsyncEventHandler<MessageCreatedEventArgs> MessageCreated;
    
    event AsyncEventHandler<MessageUpdatedEventArgs> MessageUpdated;
    
    event AsyncEventHandler<MessageDeletedEventArgs> MessageDeleted;
    
    event AsyncEventHandler<MessageReactedEventArgs> MessageReacted;
    
    event AsyncEventHandler<MessageUnreactedEventArgs> MessageUnreacted;
    
    event AsyncEventHandler<MessageReactionRemovedEventArgs> ReactionRemoved;
    
    event AsyncEventHandler<ChannelCreatedEventArgs> ChannelCreated;
    
    event AsyncEventHandler<ChannelUpdatedEventArgs> ChannelUpdated;
    
    event AsyncEventHandler<ChannelDeletedEventArgs> ChannelDeleted;
    
    event AsyncEventHandler<ChannelGroupJoinedEventArgs> GroupJoined;
    
    event AsyncEventHandler<ChannelGroupLeftEventArgs> GroupLeft;
    
    event AsyncEventHandler<ChannelTypingStartedEventArgs> TypingStarted;
    
    event AsyncEventHandler<ChannelTypingStoppedEventArgs> TypingStopped;
    
    event AsyncEventHandler<MessagesAcknowledgedEventArgs> MessagesAcknowledged;
    
    event AsyncEventHandler<ServerCreatedEventArgs> ServerCreated;
    
    event AsyncEventHandler<ServerUpdatedEventArgs> ServerUpdated;
    
    event AsyncEventHandler<ServerDeletedEventArgs> ServerDeleted;
    
    event AsyncEventHandler<ServerMemberUpdatedEventArgs> MemberUpdated;
    
    event AsyncEventHandler<ServerMemberJoinedEventArgs> MemberJoined;
    
    event AsyncEventHandler<ServerMemberLeftEventArgs> MemberLeft;
    
    event AsyncEventHandler<ServerRoleUpdatedEventArgs> RoleUpdated;
    
    event AsyncEventHandler<ServerRoleDeletedEventArgs> RoleDeleted;
    
    event AsyncEventHandler<UserUpdatedEventArgs> UserUpdated;
    
    event AsyncEventHandler<UserRelationshipUpdatedEventArgs> UserRelationshipUpdated;
    
    event AsyncEventHandler<UserPlatformDataWipedEventArgs> UserPlatformDataWiped;
    
    event AsyncEventHandler<EmojiCreatedEventArgs> EmojiCreated;
    
    event AsyncEventHandler<EmojiDeletedEventArgs> EmojiDeleted;
}