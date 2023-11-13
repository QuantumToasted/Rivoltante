using Rivoltante.Core;

namespace Rivoltante.Rest;

public static partial class RestClientExtensions
{
    public static async ValueTask<ITextChannel> CreateTextChannelAsync(this IRevoltRestClient client, Ulid serverId, string name, string? description = null, bool isNsfw = false,
        CancellationToken cancellationToken = default)
    {
        var createChannelModel = new CreateChannelApiModel(
            "Text",
            name,
            Optional<string>.FromNullable(description),
            isNsfw);

        var channelModel = await client.ApiClient.CreateChannelAsync(serverId, createChannelModel, cancellationToken);
        return new CommonTextChannel(channelModel, client);
    }
    
    public static async ValueTask<IVoiceChannel> CreateVoiceChannelAsync(this IRevoltRestClient client, Ulid serverId, string name, string? description = null, bool isNsfw = false,
        CancellationToken cancellationToken = default)
    {
        var createChannelModel = new CreateChannelApiModel(
            "Voice",
            name,
            Optional<string>.FromNullable(description),
            isNsfw);

        var channelModel = await client.ApiClient.CreateChannelAsync(serverId, createChannelModel, cancellationToken);
        return new CommonVoiceChannel(channelModel, client);
    }
}