namespace Rivoltante.Core;

public interface IMessageChannel
{
    Ulid? LastMessageId { get; }
}