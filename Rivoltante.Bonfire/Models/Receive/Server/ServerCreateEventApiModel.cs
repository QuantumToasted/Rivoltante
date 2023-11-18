using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public sealed class ServerCreateEventApiModel : ServerApiModel, IReceiveEventApiModel
{
    public ReceiveEventType? Type => ReceiveEventType.ServerCreate;
}