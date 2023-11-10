using System.Collections.Concurrent;
using System.Net;
using Microsoft.Extensions.Logging;
using Rivoltante.Rest.Extensions;

namespace Rivoltante.Rest;

public class RevoltRestRateLimitHandler : IRevoltRestRateLimitHandler
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private readonly ConcurrentDictionary<string, RateLimitBucket> _buckets = new();

    private readonly ILogger _logger;
    private readonly HttpClient _http;
    
    public RevoltRestRateLimitHandler(ILogger<RevoltRestRateLimitHandler> logger, HttpClient http)
    {
        _logger = logger;
        _http = http;
    }

    public async ValueTask<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            await _semaphore.WaitAsync(cancellationToken);

            var bucket = _buckets.GetOrAdd(request.RequestUri!.ToString(), static _ => new RateLimitBucket());

            // TODO: maximum wait time
            await bucket.WaitAsync(cancellationToken);

            var route = request.ExtractRoute(RevoltRestApiClient.BaseApiUrl);
            var response = await _http.SendAsync(request, cancellationToken);

            if (response.StatusCode is HttpStatusCode.TooManyRequests)
                throw new HttpRequestException("Route {Route} encountered a 429 Too Many Requests.", null, response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogDebug("Route {Route} encountered an error, rate limit bucket not incremented.", route);
                return response;
            }

            if (!response.TryGetRateLimitHeaders(out var headers))
                throw new ArgumentException($"Failed to get rate-limit headers for route {route}.");

            bucket.Remaining = headers.Remaining;
            bucket.ResetAfter = DateTimeOffset.UtcNow.AddMilliseconds(headers.ResetAfter);

            return response;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private class RateLimitBucket
    {
        public int Remaining { get; set; }

        public DateTimeOffset? ResetAfter { get; set; }

        public async ValueTask WaitAsync(CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            if (Remaining > 0 || !ResetAfter.HasValue || now > ResetAfter)
                return;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(ResetAfter.Value - now);
            
            try
            {
                await Task.Delay(-1, cts.Token);
            }
            catch (TaskCanceledException)
            { }
        }
    }
    /*
    private readonly record struct RateLimitBucket(string Id, int Limit, int Remaining, int RetryAfterMilliseconds)
    {
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
        
        public DateTimeOffset GetExpiry() => CreatedAt.AddMilliseconds(RetryAfterMilliseconds);
    }
    */
}