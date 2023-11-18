namespace Rivoltante.Core;

public interface IPrivateChannel : IMessageChannel
{
    IReadOnlyList<Ulid> RecipientIds { get; }
}