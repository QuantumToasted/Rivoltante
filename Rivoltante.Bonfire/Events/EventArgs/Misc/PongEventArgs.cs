namespace Rivoltante.Bonfire;

public sealed class PongEventArgs(long timestamp) : EventArgs
{
    public DateTimeOffset Timestamp { get; } = DateTimeOffset.FromUnixTimeSeconds(timestamp);
}