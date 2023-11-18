namespace Rivoltante.Core;

public interface IChannel : IUlidEntity
{
    ChannelType Type { get; }
}