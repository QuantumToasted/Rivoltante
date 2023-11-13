using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireServer : IServer, IBonfireClientEntity, IApiModelUpdatable<ServerCreateEventApiModel>, IApiModelUpdatable<ServerUpdateEventApiModel>,
    IApiModelUpdatable<ServerRoleUpdateEventApiModel>, IApiModelUpdatable<ServerMemberLeaveApiModel>,
    IApiModelUpdatable<ServerMemberJoinEventApiModel>
{
    new IReadOnlyList<IBonfireServerChannelCategory> Categories { get; }

    IReadOnlyList<IServerChannelCategory> IServer.Categories => Categories;
}