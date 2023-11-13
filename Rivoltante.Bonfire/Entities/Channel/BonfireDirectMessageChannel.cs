using Rivoltante.Core;

namespace Rivoltante.Bonfire.Channel;

public class BonfireDirectMessageChannel(IBonfireClient client, ChannelCreateEventApiModel model) : BonfirePrivateChannel(client, model), IDirectMessageChannel
{
    public bool IsActive { get; private set; }
    
    public sealed override void Update(ChannelUpdateEventApiModel model)
    {
        var updateData = model.Data;

        if (updateData.Active.HasValue)
            IsActive = updateData.Active.Value;
    }

    public sealed override void Update(ChannelCreateEventApiModel model)
    {
    }
}