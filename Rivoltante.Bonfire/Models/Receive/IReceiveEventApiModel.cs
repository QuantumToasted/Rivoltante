using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
[JsonDerivedType(typeof(ErrorEventApiModel), nameof(ReceiveEventType.Error))]
[JsonDerivedType(typeof(AuthenticatedEventApiModel), nameof(ReceiveEventType.Authenticated))]
[JsonDerivedType(typeof(BulkEventApiModel), nameof(ReceiveEventType.Bulk))]
[JsonDerivedType(typeof(ChannelAckEventApiModel), nameof(ReceiveEventType.ChannelAck))]
[JsonDerivedType(typeof(ChannelCreateEventApiModel), nameof(ReceiveEventType.ChannelCreate))]
[JsonDerivedType(typeof(ChannelDeleteEventApiModel), nameof(ReceiveEventType.ChannelDelete))]
[JsonDerivedType(typeof(ChannelGroupJoinEventApiModel), nameof(ReceiveEventType.ChannelGroupJoin))]
[JsonDerivedType(typeof(ChannelGroupLeaveEventApiModel), nameof(ReceiveEventType.ChannelGroupLeave))]
[JsonDerivedType(typeof(ChannelStartTypingEventApiModel), nameof(ReceiveEventType.ChannelStartTyping))]
[JsonDerivedType(typeof(ChannelStopTypingEventApiModel), nameof(ReceiveEventType.ChannelStopTyping))]
[JsonDerivedType(typeof(ChannelUpdateEventApiModel), nameof(ReceiveEventType.ChannelUpdate))]
[JsonDerivedType(typeof(MessageAppendEventApiModel), nameof(ReceiveEventType.MessageAppend))]
[JsonDerivedType(typeof(MessageDeleteEventApiModel), nameof(ReceiveEventType.MessageDelete))]
[JsonDerivedType(typeof(MessageEventApiModel), nameof(ReceiveEventType.Message))]
[JsonDerivedType(typeof(MessageReactEventApiModel), nameof(ReceiveEventType.MessageReact))]
[JsonDerivedType(typeof(MessageRemoveReactionEventApiModel), nameof(ReceiveEventType.MessageRemoveReaction))]
[JsonDerivedType(typeof(MessageUnreactEventApiModel), nameof(ReceiveEventType.MessageUnreact))]
[JsonDerivedType(typeof(MessageUpdateEventApiModel), nameof(ReceiveEventType.MessageUpdate))]
[JsonDerivedType(typeof(PongEventApiModel), nameof(ReceiveEventType.Pong))]
[JsonDerivedType(typeof(ReadyEventApiModel), nameof(ReceiveEventType.Ready))]
[JsonDerivedType(typeof(ServerCreateEventApiModel), nameof(ReceiveEventType.ServerCreate))]
[JsonDerivedType(typeof(ServerDeleteEventApiModel), nameof(ReceiveEventType.ServerDelete))]
[JsonDerivedType(typeof(ServerMemberJoinEventApiModel), nameof(ReceiveEventType.ServerMemberJoin))]
[JsonDerivedType(typeof(ServerMemberLeaveApiModel), nameof(ReceiveEventType.ServerMemberLeave))]
[JsonDerivedType(typeof(ServerMemberUpdateEventApiModel), nameof(ReceiveEventType.ServerMemberUpdate))]
[JsonDerivedType(typeof(ServerRoleDeleteEventApiModel), nameof(ReceiveEventType.ServerRoleDelete))]
[JsonDerivedType(typeof(ServerRoleUpdateEventApiModel), nameof(ReceiveEventType.ServerRoleUpdate))]
[JsonDerivedType(typeof(ServerUpdateEventApiModel), nameof(ReceiveEventType.ServerUpdate))]
[JsonDerivedType(typeof(UserPlatformWipeEventApiModel), nameof(ReceiveEventType.UserPlatformWipe))]
[JsonDerivedType(typeof(UserRelationshipEventApiModel), nameof(ReceiveEventType.UserRelationship))]
[JsonDerivedType(typeof(UserUpdateEventApiModel), nameof(ReceiveEventType.UserUpdate))]
[JsonDerivedType(typeof(EmojiCreateEventApiModel), nameof(ReceiveEventType.EmojiCreate))]
[JsonDerivedType(typeof(EmojiDeleteEventApiModel), nameof(ReceiveEventType.EmojiDelete))]
public interface IReceiveEventApiModel : IApiModel
{
    [JsonIgnore]
    public ReceiveEventType? Type { get; }
}