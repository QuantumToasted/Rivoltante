using System.Net.WebSockets;
using Microsoft.Extensions.Logging;
using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public class RevoltBonfireApiClient(ILogger<RevoltBonfireApiClient> logger, IBonfireConnection bonfire, IBonfireHeartbeater heartbeater, Token token) : IBonfireApiClient
{
    public IBonfireConnection Bonfire { get; } = bonfire;

    public IBonfireHeartbeater Heartbeater { get; } = heartbeater;
    
    public Token Token { get; } = token;

    public AsyncEvent<IncomingEventReceivedEventArgs> IncomingEvent { get; } = new();
    
    public async ValueTask RunAsync(Uri uri, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
            var stopHeartbeater = true;
            
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var model = await Bonfire.ReceiveAsync<IncomingEventApiModel>(cancellationToken).ConfigureAwait(false);

                    switch (model.Type)
                    {
                        case IncomingEventType.Pong:
                        {
                            await Heartbeater.AcknowledgeHeartbeatAsync().ConfigureAwait(false);
                            break;
                        }
                        default:
                        {
                            var e = new IncomingEventReceivedEventArgs(model);
                            await IncomingEvent.InvokeAsync(this, e, AsyncEventInvocationMode.Consecutive).ConfigureAwait(false);
                            break;
                        }
                    }
                }
            }
            catch (WebSocketClosedException ex) when (ex.CloseCode.HasValue)
            {
                if (ex.CloseCode.HasValue)
                {
                    logger.LogWarning("The Bonfire connection was closed with code ({Code}: {Message}).", ex.CloseCode, ex.CloseMessage);
                }
                else
                {
                    logger.LogWarning(ex, "The Bonfire connection was closed due to an exception.");
                }
            }
            catch (OperationCanceledException)
            {
                try
                {
                    await Bonfire.CloseAsync((int)WebSocketCloseStatus.Empty, null, default).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An exception occurred attempting to close the Bonfire connection after cancellation.");
                }

                throw;
            }
            catch (Exception ex) // event model issues
            {
                logger.LogCritical(ex, "An exception occured while receiving a Bonfire event. Stopping the connection.");
                
                try
                {
                    await Bonfire.CloseAsync((int)WebSocketCloseStatus.Empty, null, default).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "An exception occurred attempting to close the Bonfire connection after cancellation.");
                }
            }
            finally
            {
                if (stopHeartbeater)
                {
                    try
                    {
                        logger.LogInformation("Stopping the heartbeater due to connection termination.");
                        await Heartbeater.StopAsync().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An exception occurred attempting to stop the heartbeater.");
                    }
                }
            }
        }
    }

    private async ValueTask ConnectAsync(Uri uri, CancellationToken cancellationToken)
    {
        var attempts = 0;
        var delay = TimeSpan.FromSeconds(5);

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                if (attempts == 0)
                {
                    logger.LogInformation("Connecting to Bonfire...");
                }
                else
                {
                    logger.LogInformation("Retrying (attempt {Attempt}) connecting to Bonfire...", attempts + 1);
                }

                await Bonfire.ConnectAsync(uri, cancellationToken);
                break;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An exception occurred while connecting to Bonfire.");
                attempts++;

                if (attempts < 6)
                    delay *= 2;
                
                logger.LogInformation("Delaying the retry for {Duration}ms.", delay.TotalMilliseconds);
                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
        }
        
        logger.LogInformation("Successfully connected.");
    }
}