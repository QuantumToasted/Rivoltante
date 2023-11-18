using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class MessageEventApiModel : MessageApiModel, IReceiveEventApiModel
{
    public ReceiveEventType? Type => ReceiveEventType.Message;
}