using Rivoltante.Core;

namespace Rivoltante.Rest;

public static partial class RestApiClientExtensions
{
    public static ValueTask<ChannelApiModel> CreateChannelAsync(this IRevoltRestApiClient client, Ulid serverId, CreateChannelApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Post, FormatRoute("servers/{0}/channels", serverId), model, cancellationToken);
}
