using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireMessage : IMessage, IBonfireClientEntity, IApiModelUpdatable<MessageEventApiModel>, IApiModelUpdatable<MessageUpdateEventApiModel>, IApiModelUpdatable<MessageAppendEventApiModel>;