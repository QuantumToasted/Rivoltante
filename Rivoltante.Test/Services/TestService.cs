using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rivoltante.Core;
using Rivoltante.Rest;

namespace Rivoltante.Test.Services;

public class TestService : IHostedService
{
    private readonly IRevoltRestClient _restClient;
    private readonly ILogger _logger;

    public TestService(IRevoltRestClient restClient, ILogger<TestService> logger)
    {
        _restClient = restClient;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var messageToSend = new RevoltMessage { Content = "Hello from Rivoltante!" };
            var message = await _restClient.CreateMessageAsync("01H2SK15KZ05FZXV9XQ3QN1QBA", messageToSend, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send a message.");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}