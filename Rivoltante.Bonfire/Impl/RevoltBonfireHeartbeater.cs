using Microsoft.Extensions.Logging;

namespace Rivoltante.Bonfire;

public sealed class RevoltBonfireHeartbeater(ILogger<RevoltBonfireHeartbeater> logger, IBonfireConnection bonfire) : IBonfireHeartbeater
{
    private DateTimeOffset? _lastHeartbeatSent;
    private DateTimeOffset? _lastHeartbeatAcknowledged;
    private CancellationTokenSource? _cts;
    private Task? _heartbeatTask;
    
    public TimeSpan HeartbeatInterval { get; } = TimeSpan.FromSeconds(30); // TODO: make configurable
    
    public TimeSpan? Latency { get; }
    
    public ValueTask StartAsync(CancellationToken cancellationToken)
    {
        _lastHeartbeatSent = null;
        _lastHeartbeatAcknowledged = null;
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _heartbeatTask = Task.Run(() => RunAsync(_cts.Token), _cts.Token);
        return ValueTask.CompletedTask;
    }

    public ValueTask StopAsync()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        return ValueTask.CompletedTask;
    }

    public ValueTask HeartbeatAsync(CancellationToken cancellationToken)
    {
        _lastHeartbeatSent = DateTimeOffset.UtcNow;
        return bonfire.SendAsync(new PingEventApiModel(_lastHeartbeatSent.Value.ToUnixTimeSeconds()), cancellationToken);
    }

    public ValueTask AcknowledgeHeartbeatAsync()
    {
        _lastHeartbeatAcknowledged = DateTimeOffset.UtcNow;
        if (Latency.HasValue)
            logger.LogInformation("Heartbeat acknowledged. Latency: {Latency}ms.", (int) Latency.Value.TotalMilliseconds);
        
        return ValueTask.CompletedTask;
    }

    private async Task RunAsync(CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Delaying heartbeat for {Duration}ms.", HeartbeatInterval.TotalMilliseconds);
                await Task.Delay(HeartbeatInterval, cancellationToken).ConfigureAwait(false);
                logger.LogInformation("Heartbeating...");
                await HeartbeatAsync(cancellationToken);
            }
        }
        catch (OperationCanceledException)
        { }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception occurred while attempting to heartbeat.");
        }
    }
}