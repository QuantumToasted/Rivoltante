namespace Rivoltante.Core;

public sealed class CommonServerEmoji(EmojiApiModel model, IRevoltClient client) : IServerEmoji
{
    public IRevoltClient Client { get; } = client;

    public Ulid Id { get; } = model.Id;

    public string Name { get; } = model.Name;

    public Ulid? ServerId { get; } = model.Parent.Id.GetValueOrNullable();

    public Ulid CreatorId { get; } = model.CreatorId;

    public bool IsAnimated { get; } = model.Animated.GetValueOrDefault();

    public bool IsNsfw { get; } = model.Nsfw.GetValueOrDefault();
}