using Rivoltante.Core;
using Rivoltante.Rest.Message;

namespace Rivoltante.Rest;

public static partial class RestClientExtensions
{
    public static async Task<IMessage> CreateMessageAsync(this IRevoltRestClient client, Ulid channelId, RevoltMessage message,
        CancellationToken cancellationToken = default)
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
}