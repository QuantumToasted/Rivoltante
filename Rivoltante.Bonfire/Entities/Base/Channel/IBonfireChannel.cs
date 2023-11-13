using Rivoltante.Core;

namespace Rivoltante.Bonfire.Channel;

public interface IBonfireChannel : IChannel, IBonfireClientEntity, IApiModelUpdatable<ChannelUpdateEventApiModel>, IApiModelUpdatable<ChannelCreateEventApiModel>;