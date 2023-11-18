using Microsoft.Extensions.Logging;

namespace Rivoltante.Core;

public interface ILogs
{
    ILogger Logger { get; }
}