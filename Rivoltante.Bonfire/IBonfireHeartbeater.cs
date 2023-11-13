namespace Rivoltante.Bonfire;

public interface IBonfireHeartbeater
{
    TimeSpan HeartbeatInterval { get; }
    
    TimeSpan? Latency { get; }

    ValueTask StartAsync(CancellationToken cancellationToken);

    ValueTask StopAsync();

    ValueTask HeartbeatAsync(CancellationToken cancellationToken);

    ValueTask AcknowledgeHeartbeatAsync();
}