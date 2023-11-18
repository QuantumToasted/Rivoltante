using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface ISendEventApiModel : IApiModel
{
    SendEventType Type { get; }
}