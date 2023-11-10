using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed class RestUnknownChannel(ChannelApiModel model, IRevoltClient client) : RestChannel(model, client);