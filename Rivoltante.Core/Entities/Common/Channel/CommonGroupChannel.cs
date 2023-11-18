namespace Rivoltante.Core;

public sealed class CommonGroupChannel(ChannelApiModel model, IRevoltClient client) : CommonChannel(model, client), IGroupChannel
{
    public string Name { get; } = model.Name.Value;

    public Ulid OwnerId { get; } = model.Owner.Value;

    public string? Description { get; } = model.Description.GetValueOrDefault();

    public IReadOnlyList<Ulid> RecipientIds { get; } = model.Recipients.GetValueOrFallback(Array.Empty<Ulid>());

    public IAttachment? Icon { get; } = Optional<IAttachment>.ConvertOrDefault(model.Icon, x => new CommonAttachment(x));

    public Ulid? LastMessageId { get; } = model.LastMessageId.GetValueOrDefault();

    public Permission? Permissions { get; } = model.Permissions.GetValueOrDefault();

    public bool IsNsfw { get; } = model.Nsfw.GetValueOrDefault();

    public override ChannelType Type => ChannelType.Group;
}