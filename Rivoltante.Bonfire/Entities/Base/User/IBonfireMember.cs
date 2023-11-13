using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireMember : IBonfireUser, IServerEntity, IApiModelUpdatable<ServerMemberUpdateEventApiModel>, IApiModelUpdatable<ServerMemberJoinEventApiModel>;