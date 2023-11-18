namespace Rivoltante.Bonfire;

public sealed class ErrorEventArgs(string rawEventId) : EventArgs
{
    public string RawEventId { get; } = rawEventId;

    public ErrorEventId? EventId => Enum.TryParse(RawEventId, out ErrorEventId id) ? id : null;
}