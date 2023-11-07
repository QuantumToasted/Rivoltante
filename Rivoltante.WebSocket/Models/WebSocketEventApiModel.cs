using Rivoltante.Core;

namespace Rivoltante.WebSocket.Models;

public abstract record WebSocketEventApiModel(string Type) : ApiModel;