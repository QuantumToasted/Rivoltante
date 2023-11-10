namespace Rivoltante.Core;

public interface IDirectMessageChannel : IPrivateChannel
{
    bool IsActive { get; }
}