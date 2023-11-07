using Rivoltante.Core;

namespace Rivoltante.Rest;

public static partial class RestApiClientExtensions
{
    public static ValueTask<MessageApiModel> CreateMessageAsync(this IRevoltRestApiClient client, Ulid channelId, CreateMessageApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<MessageApiModel>(HttpMethod.Post, FormatRoute("channels/{0}/messages", channelId), model, cancellationToken);
}