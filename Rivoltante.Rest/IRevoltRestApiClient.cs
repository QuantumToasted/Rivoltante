using Rivoltante.Core;

namespace Rivoltante.Rest;

public interface IRevoltRestApiClient : IRevoltApiClient
{
    IRevoltRestRateLimitHandler RateLimitHandler { get; }
    
    ValueTask RequestAsync(HttpMethod method, string route, ApiModel? model = null, CancellationToken cancellationToken = default);
    
    ValueTask<TModel> RequestAsync<TModel>(HttpMethod method, string route, ApiModel? model = null, CancellationToken cancellationToken = default)
        where TModel : ApiModel;
    
    ValueTask<TModel[]> RequestArrayAsync<TModel>(HttpMethod method, string route, ApiModel? model = null, CancellationToken cancellationToken = default)
        where TModel : ApiModel;
}