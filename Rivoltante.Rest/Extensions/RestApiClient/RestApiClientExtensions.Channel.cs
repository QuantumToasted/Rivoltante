using Rivoltante.Core;

namespace Rivoltante.Rest;

public static partial class RestApiClientExtensions
{
    public static ValueTask<MessageApiModel> CreateMessageAsync(this IRevoltRestApiClient client, Ulid channelId, CreateMessageApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<MessageApiModel>(HttpMethod.Post, FormatRoute("channels/{0}/messages", channelId), model, cancellationToken);

    public static ValueTask<ChannelApiModel> FetchChannelAsync(this IRevoltRestApiClient client, Ulid channelId, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Get, FormatRoute("channels/{0}", channelId), cancellationToken: cancellationToken);

    public static ValueTask CloseChannelAsync(this IRevoltRestApiClient client, Ulid channelId, bool leaveSilently = false, CancellationToken cancellationToken = default)
        => client.RequestAsync(HttpMethod.Delete, FormatRoute("channels/{0}", new Dictionary<string, object> { ["leave_silently"] = leaveSilently }, channelId), cancellationToken: cancellationToken);

    public static ValueTask<ChannelApiModel> EditChannelAsync(this IRevoltRestApiClient client, Ulid channelId, EditChannelApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Patch, FormatRoute("channels/{0}", channelId), model, cancellationToken);
}