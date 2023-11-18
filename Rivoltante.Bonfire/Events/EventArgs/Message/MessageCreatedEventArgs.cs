using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageCreatedEventArgs(IMessage message) : EventArgs
{
    public IMessage Message { get; } = message;
    
    public Ulid MessageId => Message.Id;

    public Ulid ChannelId => Message.ChannelId;

    public Ulid AuthorId => Message.AuthorId;
}