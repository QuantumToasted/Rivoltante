namespace Rivoltante.Core;

public interface IMessageChannel : IChannel
{
    Ulid? LastMessageId { get; }
}