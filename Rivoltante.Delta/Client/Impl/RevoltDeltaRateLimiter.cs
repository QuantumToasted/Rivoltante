using System.Collections.Concurrent;
using System.Net;
using Microsoft.Extensions.Logging;
using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class RevoltDeltaRateLimiter(ILogger<RevoltDeltaRateLimiter> logger, HttpClient http) : IDeltaRateLimiter
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private readonly ConcurrentDictionary<string, RateLimitBucket> _buckets = new();
    
    public ILogger Logger { get; } = logger;

    public async ValueTask<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        using var _ = await _semaphore.EnterAsync(cancellationToken).ConfigureAwait(false);
        
        var route = request.ExtractRoute(RevoltDeltaApiClient.BaseApiUrl);
        var bucket = _buckets.GetOrAdd(route, static _ => new RateLimitBucket());

        // TODO: maximum wait time
        await bucket.WaitAsync(cancellationToken).ConfigureAwait(false);

        var response = await http.SendAsync(request, cancellationToken).ConfigureAwait(false);

        if (response.StatusCode is HttpStatusCode.TooManyRequests)
            throw new HttpRequestException($"Route {route} encountered a 429 Too Many Requests.", null, response.StatusCode);

        if (!response.IsSuccessStatusCode)
        {
            Logger.LogDebug("Route {Route} encountered an error, rate limit bucket not incremented.", route);
        }
        else if (!response.TryGetRateLimitHeaders(out var headers))
        {
            throw new HttpRequestException($"Route {route} did not contain rate limiting headers.");
        }
        else
        {
            bucket.Remaining = headers.Remaining;
            bucket.ResetAfter = DateTimeOffset.UtcNow.AddMilliseconds(headers.ResetAfter);
            
            Logger.LogDebug("Route {Route}: {Current}/{Total} requests remaining (reset after {Duration}).",
                route, bucket.Initial - bucket.Remaining, bucket.Remaining, bucket.ResetAfter - DateTimeOffset.UtcNow);
        }
        
        return response;
    }

    private class RateLimitBucket
    {
        private int _remaining;

        public int Initial { get; set; } = int.MinValue;
        
        public int Remaining
        {
            get => _remaining;
            set
            {
                _remaining = value;
                if (Initial == int.MinValue)
                    Initial = value;
            }
        }

        public DateTimeOffset ResetAfter { get; set; } = DateTimeOffset.MinValue;

        public async ValueTask WaitAsync(CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            if (Remaining > 0 || now > ResetAfter)
                return;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(ResetAfter - now);
            
            try
            {
                await Task.Delay(-1, cts.Token);
            }
            catch (TaskCanceledException)
            { }
        }
    }
}