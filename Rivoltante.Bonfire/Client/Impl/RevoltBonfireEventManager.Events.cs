namespace Rivoltante.Bonfire;

public sealed partial class RevoltBonfireEventManager
{
    public AsyncEvent<ErrorEventArgs> ErrorEvent { get; } = new();
    
    public AsyncEvent<AuthenticatedEventArgs> AuthenticatedEvent { get; } = new();
    
    public AsyncEvent<PongEventArgs> PongEvent { get; } = new();
    
    public AsyncEvent<ReadyEventArgs> ReadyEvent { get; } = new();
    
    public AsyncEvent<MessageCreatedEventArgs> MessageCreatedEvent { get; } = new();
    
    public AsyncEvent<MessageUpdatedEventArgs> MessageUpdatedEvent { get; } = new();
    
    public AsyncEvent<MessageDeletedEventArgs> MessageDeletedEvent { get; } = new();
    
    public AsyncEvent<MessageReactedEventArgs> MessageReactedEvent { get; } = new();
    
    public AsyncEvent<MessageUnreactedEventArgs> MessageUnreactedEvent { get; } = new();
    
    public AsyncEvent<MessageReactionRemovedEventArgs> ReactionRemovedEvent { get; } = new();
    
    public AsyncEvent<ChannelCreatedEventArgs> ChannelCreatedEvent { get; } = new();
    
    public AsyncEvent<ChannelUpdatedEventArgs> ChannelUpdatedEvent { get; } = new();
    
    public AsyncEvent<ChannelDeletedEventArgs> ChannelDeletedEvent { get; } = new();
    
    public AsyncEvent<ChannelGroupJoinedEventArgs> GroupJoinedEvent { get; } = new();
    
    public AsyncEvent<ChannelGroupLeftEventArgs> GroupLeftEvent { get; } = new();
    
    public AsyncEvent<ChannelTypingStartedEventArgs> TypingStartedEvent { get; } = new();
    
    public AsyncEvent<ChannelTypingStoppedEventArgs> TypingStoppedEvent { get; } = new();
    
    public AsyncEvent<MessagesAcknowledgedEventArgs> MessagesAcknowledgedEvent { get; } = new();
    
    public AsyncEvent<ServerCreatedEventArgs> ServerCreatedEvent { get; } = new();
    
    public AsyncEvent<ServerUpdatedEventArgs> ServerUpdatedEvent { get; } = new();
    
    public AsyncEvent<ServerDeletedEventArgs> ServerDeletedEvent { get; } = new();
    
    public AsyncEvent<ServerMemberUpdatedEventArgs> MemberUpdatedEvent { get; } = new();
    
    public AsyncEvent<ServerMemberJoinedEventArgs> MemberJoinedEvent { get; } = new();
    
    public AsyncEvent<ServerMemberLeftEventArgs> MemberLeftEvent { get; } = new();
    
    public AsyncEvent<ServerRoleUpdatedEventArgs> RoleUpdatedEvent { get; } = new();
    
    public AsyncEvent<ServerRoleDeletedEventArgs> RoleDeletedEvent { get; } = new();
    
    public AsyncEvent<UserUpdatedEventArgs> UserUpdatedEvent { get; } = new();
    
    public AsyncEvent<UserRelationshipUpdatedEventArgs> UserRelationshipUpdatedEvent { get; } = new();
    
    public AsyncEvent<UserPlatformDataWipedEventArgs> UserPlatformDataWipedEvent { get; } = new();
    
    public AsyncEvent<EmojiCreatedEventArgs> EmojiCreatedEvent { get; } = new();
    
    public AsyncEvent<EmojiDeletedEventArgs> EmojiDeletedEvent { get; } = new();
}