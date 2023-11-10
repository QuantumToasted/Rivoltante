using Rivoltante.Core;

namespace Rivoltante.Rest;

public static partial class RestApiClientExtensions
{
    public static ValueTask<MessageApiModel> CreateMessageAsync(this IRevoltRestApiClient client, Ulid channelId, CreateMessageApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<MessageApiModel>(HttpMethod.Post, FormatRoute("channels/{0}/messages", channelId), model, cancellationToken);

    public static ValueTask AcknowledgeMessageAsync(this IRevoltRestApiClient client, Ulid channelId, Ulid messageId, CancellationToken cancellationToken = default)
        => client.RequestAsync(HttpMethod.Put, FormatRoute("channels/{0}/ack/{1}", channelId, messageId), null, cancellationToken);

    public static ValueTask<MessageApiModel> FetchMessageAsync(this IRevoltRestApiClient client, Ulid channelId, Ulid messageId, CancellationToken cancellationToken = default)
        => client.RequestAsync<MessageApiModel>(HttpMethod.Get, FormatRoute("channels/{0}/messages/{1}", channelId, messageId), null, cancellationToken);

    public static async ValueTask<BulkMessagesApiModel> FetchMessagesAsync(this IRevoltRestApiClient client, Ulid channelId, int? limit, Ulid? beforeMessageId, Ulid? afterMessageId, MessageSortOrder? sortOrder, Ulid? nearMessageId, bool? includeUsers, CancellationToken cancellationToken = default)
    {
        var dict = new Dictionary<string, object>();

        if (limit.HasValue)
            dict["limit"] = limit.Value;

        if (beforeMessageId.HasValue)
            dict["before"] = beforeMessageId.Value;

        if (afterMessageId.HasValue)
            dict["after"] = afterMessageId.Value;

        if (sortOrder.HasValue)
            dict["sort"] = sortOrder.Value.ToString("G");

        if (nearMessageId.HasValue)
            dict["nearby"] = nearMessageId.Value;

        if (includeUsers.HasValue)
            dict["include_users"] = includeUsers.Value;

        var route = FormatRoute("channels/{0}/messages", dict, channelId);

        if (includeUsers is true)
            return await client.RequestAsync<BulkMessagesApiModel>(HttpMethod.Get, route, null, cancellationToken);

        var messages = await client.RequestArrayAsync<MessageApiModel>(HttpMethod.Get, route, null, cancellationToken);
        return new BulkMessagesApiModel(messages, Array.Empty<UserApiModel>(), Array.Empty<MemberApiModel>());
    }

    public static async ValueTask<BulkMessagesApiModel> SearchForMessagesAsync(this IRevoltRestApiClient client, Ulid channelId, SearchChannelMessagesApiModel model, CancellationToken cancellationToken = default)
    {
        var route = FormatRoute("channels/{0}/search", channelId);
        
        if (model.IncludeUsers.GetValueOrDefault())
            return await client.RequestAsync<BulkMessagesApiModel>(HttpMethod.Get, route, model, cancellationToken);

        var messages = await client.RequestArrayAsync<MessageApiModel>(HttpMethod.Get, route, model, cancellationToken);
        return new BulkMessagesApiModel(messages, Array.Empty<UserApiModel>(), Array.Empty<MemberApiModel>());
    }
    
    public static ValueTask DeleteMessageAsync(this IRevoltRestApiClient client, Ulid channelId, Ulid messageId, CancellationToken cancellationToken = default)
        => client.RequestAsync(HttpMethod.Delete, FormatRoute("channels/{0}/messages/{1}", channelId, messageId), null, cancellationToken);

    public static ValueTask DeleteMessagesAsync(this IRevoltRestApiClient client, Ulid channelId, BulkDeleteMessagesApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync(HttpMethod.Delete, FormatRoute("channels/{0}/messages/bulk", channelId), model, cancellationToken);
    
    public static ValueTask<ChannelApiModel> FetchChannelAsync(this IRevoltRestApiClient client, Ulid channelId, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Get, FormatRoute("channels/{0}", channelId), cancellationToken: cancellationToken);

    public static ValueTask CloseChannelAsync(this IRevoltRestApiClient client, Ulid channelId, bool? leaveSilently, CancellationToken cancellationToken = default)
    {
        var dict = new Dictionary<string, object>();

        if (leaveSilently.HasValue)
            dict["leave_silently"] = leaveSilently.Value;
        
        return client.RequestAsync(HttpMethod.Delete, FormatRoute("channels/{0}", dict, channelId), cancellationToken: cancellationToken);
    }

    public static ValueTask<ChannelApiModel> EditChannelAsync(this IRevoltRestApiClient client, Ulid channelId, EditChannelApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Patch, FormatRoute("channels/{0}", channelId), model, cancellationToken);

    public static ValueTask<InviteApiModel> CreateInviteAsync(this IRevoltRestApiClient client, Ulid channelId, CancellationToken cancellationToken = default)
        => client.RequestAsync<InviteApiModel>(HttpMethod.Post, FormatRoute("channels/{0}/invites", channelId), null, cancellationToken);

    public static ValueTask<ChannelApiModel> SetRolePermissionsAsync(this IRevoltRestApiClient client, Ulid channelId, Ulid roleId, SetChannelRolePermissionsApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Put, FormatRoute("channels/{0}/permissions/{1}", channelId, roleId), model, cancellationToken);

    public static ValueTask<ChannelApiModel> SetGroupChannelDefaultPermissionsAsync(this IRevoltRestApiClient client, Ulid channelId, SetGroupChannelDefaultPermissionsApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Put, FormatRoute("channels/{0}/permissions/default", channelId), model, cancellationToken);
    
    public static ValueTask<ChannelApiModel> SetServerChannelDefaultPermissionsAsync(this IRevoltRestApiClient client, Ulid channelId, SetServerChannelDefaultPermissionsApiModel model, CancellationToken cancellationToken = default)
        => client.RequestAsync<ChannelApiModel>(HttpMethod.Put, FormatRoute("channels/{0}/permissions/default", channelId), model, cancellationToken);

    public static ValueTask AddMessageReactionAsync(this IRevoltRestApiClient client, Ulid channelId, Ulid messageId, IEmoji emoji, CancellationToken cancellationToken = default)
        => client.RequestAsync(HttpMethod.Put, FormatRoute("channels/{0}/messages/{1}/reactions/{2}", channelId, messageId, emoji.Value), null, cancellationToken);

    public static ValueTask RemoveMessageReactionsAsync(this IRevoltRestApiClient client, Ulid channelId, Ulid messageId, IEmoji emoji, Ulid? userId, bool? removeAll, CancellationToken cancellationToken = default)
    {
        var dict = new Dictionary<string, object>();

        if (userId.HasValue)
            dict["user_id"] = userId.Value;

        if (removeAll.HasValue)
            dict["remove_all"] = removeAll.Value;

        return client.RequestAsync(HttpMethod.Delete, FormatRoute("channels/{0}/messages/{1}/reactions/{2}", dict, channelId, messageId, emoji.Value), null, cancellationToken);
    }

    public static ValueTask RemoveAllMessageReactionsAsync(this IRevoltRestApiClient client, Ulid channelId, Ulid messageId, CancellationToken cancellationToken = default)
        => client.RequestAsync(HttpMethod.Delete, FormatRoute("channels/{0}/messages/{1}/reactions", channelId, messageId), null, cancellationToken);
}