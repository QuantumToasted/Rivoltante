using System.Net;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public static partial class RestClientExtensions
{
    public static async ValueTask<IMessage> CreateMessageAsync(this IRevoltRestClient client, Ulid channelId, RevoltMessage message, CancellationToken cancellationToken = default)
    {
        var createMessageModel = new CreateMessageApiModel(
            Optional<string>.FromNullable(message.Content),
            Optional<string[]>.FromNullable(message.Attachments?.ToArray()),
            Optional<CreateMessageReplyApiModel[]>.Convert<IList<RevoltMessageReply>?, CreateMessageReplyApiModel[]>(
                message.Replies?.ToList(), static x => x!.Select(ConvertReply).ToArray()),
            Optional<CreateMessageEmbedApiModel[]>.Convert<IList<RevoltMessageEmbed>?, CreateMessageEmbedApiModel[]>(
                message.Embeds?.ToList(), static x => x!.Select(ConvertEmbed).ToArray()),
            Optional<MessageMasqueradeApiModel>.Convert<RevoltMessageMasquerade, MessageMasqueradeApiModel>(message.Masquerade, ConvertMasquerade),
            Optional<MessageInteractionsApiModel>.Convert<RevoltMessageInteractions, MessageInteractionsApiModel>(message.Interactions, ConvertInteractions));

        var messageModel = await client.ApiClient.CreateMessageAsync(channelId, createMessageModel, cancellationToken);
        return new CommonMessage(client, messageModel);

        static CreateMessageReplyApiModel ConvertReply(RevoltMessageReply reply)
            => new(reply.MessageId, reply.MentionAuthor);

        static CreateMessageEmbedApiModel ConvertEmbed(RevoltMessageEmbed embed)
        {
            return new CreateMessageEmbedApiModel(
                Optional<string>.FromNullable(embed.IconUrl),
                Optional<string>.FromNullable(embed.Url),
                Optional<string>.FromNullable(embed.Title),
                Optional<string>.FromNullable(embed.Description),
                Optional<string>.FromNullable(embed.Media),
                Optional<string>.FromNullable(embed.Color));
        }

        static MessageMasqueradeApiModel ConvertMasquerade(RevoltMessageMasquerade masquerade)
        {
            return new MessageMasqueradeApiModel(Optional<string>.FromNullable(masquerade.Name),
                Optional<string>.FromNullable(masquerade.AvatarUrl),
                Optional<string>.FromNullable(masquerade.Color));
        }

        static MessageInteractionsApiModel ConvertInteractions(RevoltMessageInteractions interactions)
            => new(interactions.Reactions.ToArray(), interactions.RestrictReactions);
    }

    public static ValueTask AcknowledgeMessageAsync(this IRevoltRestClient client, Ulid channelId, Ulid messageId, CancellationToken cancellationToken = default)
        => client.ApiClient.AcknowledgeMessageAsync(channelId, messageId, cancellationToken);

    public static async ValueTask<IMessage?> FetchMessageAsync(this IRevoltRestClient client, Ulid channelId, Ulid messageId, CancellationToken cancellationToken = default)
    {
        try
        {
            var model = await client.ApiClient.FetchMessageAsync(channelId, messageId, cancellationToken);
            return new CommonMessage(client, model);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public static async ValueTask<IBulkMessages> FetchMessagesAsync(this IRevoltRestClient client, Ulid channelId, int? limit = null, Ulid? beforeMessageId = null, Ulid? afterMessageId = null, MessageSortOrder? sortOrder = null, Ulid? nearMessageId = null, bool? includeUsers = null, CancellationToken cancellationToken = default)
    {
        var model = await client.ApiClient.FetchMessagesAsync(channelId, limit, beforeMessageId, afterMessageId, sortOrder, nearMessageId, includeUsers, cancellationToken);
        return new RestBulkMessages(model, client);
    }

    public static async ValueTask<IBulkMessages> SearchForMessagesAsync(this IRevoltRestClient client, Ulid channelId, RevoltMessageSearch search, CancellationToken cancellationToken = default)
    {
        var searchMessageModel = new SearchChannelMessagesApiModel(
            search.Query,
            Optional<int>.FromNullable(search.Limit),
            Optional<Ulid>.FromNullable(search.BeforeMessageId),
            Optional<Ulid>.FromNullable(search.AfterMessageId),
            Optional<MessageSortOrder>.FromNullable(search.SortOrder),
            Optional<bool>.FromNullable(search.IncludeUsers));

        var messagesModel = await client.ApiClient.SearchForMessagesAsync(channelId, searchMessageModel, cancellationToken);
        return new RestBulkMessages(messagesModel, client);
    }
    
    public static ValueTask CloseChannelAsync(this IRevoltRestClient client, Ulid channelId, bool leaveGroupSilently = false, CancellationToken cancellationToken = default)
        => client.ApiClient.CloseChannelAsync(channelId, leaveGroupSilently, cancellationToken);

    public static async ValueTask<IServerChannel> ModifyServerChannelAsync(this IRevoltRestClient client, Ulid channelId, Action<EditChannelProperties> action, CancellationToken cancellationToken = default)
    {
        var model = await client.InternalEditChannelAsync(channelId, action, cancellationToken);
        return (IServerChannel)CommonChannel.Create(model, client);
    }

    public static async ValueTask<IGroupChannel> ModifyGroupChannelAsync(this IRevoltRestClient client, Ulid channelId, Action<EditGroupChannelProperties> action, CancellationToken cancellationToken = default)
    {
        var model = await client.InternalEditChannelAsync(channelId, action, cancellationToken);
        return (IGroupChannel) CommonChannel.Create(model, client);
    }

    public static async ValueTask<IInvite> CreateInviteAsync(this IRevoltRestClient client, Ulid channelId, CancellationToken cancellationToken = default)
    {
        var model = await client.ApiClient.CreateInviteAsync(channelId, cancellationToken);
        return CommonInvite.Create(model, client);
    }

    public static async ValueTask<IServerChannel> SetRolePermissionsAsync(this IRevoltRestClient client, Ulid channelId, Ulid roleId, Permission allowed, Permission denied, CancellationToken cancellationToken = default)
    {
        var model = await client.ApiClient.SetRolePermissionsAsync(channelId, roleId, new SetChannelRolePermissionsApiModel(new RolePermissionsApiModel(allowed, denied)), cancellationToken);
        return (IServerChannel)CommonChannel.Create(model, client);
    }

    public static async ValueTask<IGroupChannel> SetGroupChannelDefaultPermissionsAsync(this IRevoltRestClient client, Ulid channelId, Permission permissions, CancellationToken cancellationToken = default)
    {
        var model = await client.ApiClient.SetGroupChannelDefaultPermissionsAsync(channelId, new SetGroupChannelDefaultPermissionsApiModel(permissions), cancellationToken);
        return (IGroupChannel)CommonChannel.Create(model, client);
    }
    
    public static async ValueTask<IServerChannel> SetServerChannelDefaultPermissionsAsync(this IRevoltRestClient client, Ulid channelId, Permission allowed, Permission denied, CancellationToken cancellationToken = default)
    {
        var model = await client.ApiClient.SetServerChannelDefaultPermissionsAsync(channelId, new SetServerChannelDefaultPermissionsApiModel(new RolePermissionsApiModel(allowed, denied)), cancellationToken);
        return (IServerChannel)CommonChannel.Create(model, client);
    }
    
    private static ValueTask<ChannelApiModel> InternalEditChannelAsync<TProperties>(this IRevoltRestClient client, Ulid channelId, Action<TProperties> action, CancellationToken cancellationToken = default)
        where TProperties : EditChannelProperties
    {
        var properties = (TProperties)Activator.CreateInstance(typeof(TProperties), true)!;
        action.Invoke(properties);

        var model = new EditChannelApiModel(
            properties.Name,
            properties.Description,
            Optional<Ulid>.FromNullable((properties as EditGroupChannelProperties)?.OwnerId.GetValueOrNullable()),
            properties.Icon,
            properties.IsNsfw,
            properties.IsArchived,
            Optional<RemoveChannelField[]>.Convert(properties.RemovedChannelFields, x => x.ToArray()));

        return client.ApiClient.EditChannelAsync(channelId, model, cancellationToken);
    }
}