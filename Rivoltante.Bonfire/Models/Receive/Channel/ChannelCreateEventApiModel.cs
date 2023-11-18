using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ChannelCreateEventApiModel : ChannelApiModel, IReceiveEventApiModel
{
    public ReceiveEventType? Type => ReceiveEventType.ChannelCreate;
}
    
    