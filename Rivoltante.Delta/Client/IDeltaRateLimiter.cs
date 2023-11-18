using Rivoltante.Core;

namespace Rivoltante.Delta;

public interface IDeltaRateLimiter : ILogs
{
    ValueTask<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}