namespace Rivoltante.Bonfire;

public interface IBonfireConnection : IAsyncDisposable
{
    ValueTask ConnectAsync(Uri uri, CancellationToken cancellationToken);

    ValueTask CloseAsync(int closeCode, string? closeMessage, CancellationToken cancellationToken);
    
    ValueTask<TModel> ReceiveAsync<TModel>(CancellationToken cancellationToken) where TModel : IncomingEventApiModel;

    ValueTask SendAsync<TModel>(TModel model, CancellationToken cancellationToken) where TModel : OutgoingEventApiModel;
}