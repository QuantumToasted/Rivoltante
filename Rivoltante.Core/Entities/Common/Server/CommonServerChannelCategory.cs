namespace Rivoltante.Core;

public sealed class CommonServerChannelCategory(ServerChannelCategoryApiModel model) : IServerChannelCategory
{
    public Ulid Id { get; } = model.Id;

    public string Title { get; } = model.Title;

    public IReadOnlyList<Ulid> ChannelIds { get; } = model.Channels;
}