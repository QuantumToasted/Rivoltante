using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class CreateServerResponseApiModel : IApiModel
{
    public required ServerApiModel Server { get; init; }
    
    public required ChannelApiModel[] Channels { get; init; }
}