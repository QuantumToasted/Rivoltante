using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageUpdatedEventArgs(Ulid messageId, Ulid channelId, PartialMessageUpdateApiModel model) : EventArgs
{
    public Ulid MessageId { get; } = messageId;
    
    public Ulid ChannelId { get; } = channelId;
    
    public PartialMessageUpdateApiModel Model { get; } = model;
}