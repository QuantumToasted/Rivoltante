namespace Rivoltante.Bonfire;

public sealed class ErrorEventApiModel : IReceiveEventApiModel
{
    public required string Error { get; init; }

    public ErrorEventId? GetErrorId()
        => Enum.TryParse(Error, out ErrorEventId id) ? id : null;

    public ReceiveEventType? Type => ReceiveEventType.Error;
}