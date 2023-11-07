using Microsoft.Extensions.Logging;

namespace Rivoltante.Core;

public interface IRevoltClient
{
    IRevoltApiClient ApiClient { get; }
    
    ILogger Logger { get; }
}