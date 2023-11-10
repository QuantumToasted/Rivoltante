namespace Rivoltante.Rest;

internal static class HttpExtensions
{
    public static string ExtractRoute(this HttpRequestMessage request, string basePath)
        => request.RequestUri!.ToString()[basePath.Length..];

    public static bool TryGetRateLimitHeaders(this HttpResponseMessage response, out (int Limit, string Bucket, int Remaining, int ResetAfter) headers)
    {
        const string headerPrefix = "X-RateLimit";

        headers = default;

        if (!response.Headers.TryGetValues($"{headerPrefix}-Limit", out var limit) ||
            !response.Headers.TryGetValues($"{headerPrefix}-Bucket", out var bucket) ||
            !response.Headers.TryGetValues($"{headerPrefix}-Remaining", out var remaining) ||
            !response.Headers.TryGetValues($"{headerPrefix}-Reset-After", out var resetAfter))
        {
            return false;
        }

        headers = (int.Parse(limit.First()), bucket.First(), int.Parse(remaining.First()), int.Parse(resetAfter.First()));
        return true;
    }
}