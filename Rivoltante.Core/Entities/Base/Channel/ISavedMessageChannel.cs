namespace Rivoltante.Core;

public interface ISavedMessageChannel : IChannel
{
    Ulid UserId { get; }
}