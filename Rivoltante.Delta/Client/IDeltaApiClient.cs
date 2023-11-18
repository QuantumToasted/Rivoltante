using Rivoltante.Core;

namespace Rivoltante.Delta;

public interface IDeltaApiClient : IRevoltApiClient
{
    IDeltaRateLimiter RateLimiter { get; }
    
    ValueTask RequestAsync(HttpMethod method, string route, IApiModel? model = null, CancellationToken cancellationToken = default);
    
    ValueTask<TModel> RequestAsync<TModel>(HttpMethod method, string route, IApiModel? model = null, CancellationToken cancellationToken = default)
        where TModel : IApiModel;
    
    //ValueTask<TModel[]> RequestArrayAsync<TModel>(HttpMethod method, string route, IApiModel? model = null, CancellationToken cancellationToken = default)
    //    where TModel : IApiModel;
}