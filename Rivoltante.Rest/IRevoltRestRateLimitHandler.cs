namespace Rivoltante.Rest;

public interface IRevoltRestRateLimitHandler
{
    ValueTask<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}