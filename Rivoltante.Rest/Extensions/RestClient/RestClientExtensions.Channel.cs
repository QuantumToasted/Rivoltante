using Rivoltante.Core;
using Rivoltante.Rest.Message;

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
        return new RestMessage(client, messageModel);

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
    
    public static ValueTask CloseChannelAsync(this IRevoltRestClient client, Ulid channelId, bool leaveGroupSilently = false, CancellationToken cancellationToken = default)
        => client.ApiClient.CloseChannelAsync(channelId, leaveGroupSilently, cancellationToken);

    public static async ValueTask<IServerChannel> ModifyServerChannelAsync(this IRevoltRestClient client, Ulid channelId, Action<EditChannelProperties> action, CancellationToken cancellationToken = default)
    {
        var model = await client.InternalEditChannelAsync(channelId, action, cancellationToken);
        return (IServerChannel)RestChannel.Create(model, client);
    }

    public static async ValueTask<IGroupChannel> ModifyGroupChannelAsync(this IRevoltRestClient client, Ulid channelId, Action<EditGroupChannelProperties> action, CancellationToken cancellationToken = default)
    {
        var model = await client.InternalEditChannelAsync(channelId, action, cancellationToken);
        return (IGroupChannel) RestChannel.Create(model, client);
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