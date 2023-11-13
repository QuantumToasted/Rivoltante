namespace Rivoltante.Bonfire;

public sealed record AuthenticatedEventApiModel() : IncomingEventApiModel(IncomingEventType.Authenticated);