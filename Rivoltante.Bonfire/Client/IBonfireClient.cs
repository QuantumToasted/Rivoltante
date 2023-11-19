using System.Text.Json;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public partial interface IBonfireClient : IRevoltClient
{
    //new IBonfireApiClient ApiClient { get; }
    
    JsonSerializerOptions SerializerOptions { get; }
    
    IBonfireEventManager EventManager { get; }
    
    AsyncEvent<BonfireReceivedEventArgs> ReceivedEvent { get; }

    ValueTask RunAsync(Uri uri, CancellationToken cancellationToken);

    ValueTask SendAsync<TModel>(TModel model, CancellationToken cancellationToken) where TModel : class, ISendEventApiModel;

    ValueTask<TModel> ReceiveAsync<TModel>(CancellationToken cancellationToken) where TModel : class, IReceiveEventApiModel;

    //IRevoltApiClient IRevoltClient.ApiClient => ApiClient;
}