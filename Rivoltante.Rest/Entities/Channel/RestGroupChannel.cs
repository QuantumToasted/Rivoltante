using Rivoltante.Core;
using Rivoltante.Rest.Message;

namespace Rivoltante.Rest;

public sealed class RestGroupChannel(ChannelApiModel model, IRevoltClient client) : RestChannel(model, client), IGroupChannel
{
    public string Name { get; } = model.Name.Value;

    public Ulid OwnerId { get; } = model.Owner.Value;

    public string? Description { get; } = model.Description.GetValueOrDefault();

    public IReadOnlyList<Ulid> RecipientIds { get; } = model.Recipients.GetValueOrFallback(Array.Empty<Ulid>());

    public IAttachment? Icon { get; } = model.Icon.HasValue ? new RestAttachment(model.Icon.Value) : null;

    public Ulid? LastMessageId { get; } = model.LastMessageId.GetValueOrDefault();

    public Permissions? Permissions { get; } = model.Permissions.GetValueOrDefault();

    public bool IsNsfw { get; } = model.Nsfw.GetValueOrDefault();
}