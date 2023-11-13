using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageEventArgs(IBonfireMessage message) : EventArgs
{
    public IBonfireMessage Message { get; } = message;

    public Ulid MessageId => Message.Id;

    public Ulid ChannelId => Message.ChannelId;

    public Ulid AuthorId => Message.AuthorId;
}