using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Rivoltante.Core;
using Rivoltante.Rest;
using Rivoltante.Test.Services;
using Serilog;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

var host = new HostBuilder()
    .ConfigureHostConfiguration(x => x.AddEnvironmentVariables("RIVOLTANTE_"))
    .ConfigureLogging(x =>
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        x.AddSerilog(Log.Logger);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<HttpClient>();
        
        services.AddSingleton<RevoltRestRateLimitHandler>();
        services.AddSingleton<IRevoltRestRateLimitHandler>(x => x.GetRequiredService<RevoltRestRateLimitHandler>());

        services.AddSingleton(new JsonSerializer
            { Converters = { new OptionalJsonConverter() }, ContractResolver = new OptionalJsonContractResolver() });
        //services.AddSingleton<JsonSerializer>();

        var token = new BotToken(context.Configuration["TOKEN"]!);
        services.AddSingleton(token);
        services.AddSingleton<Token>(x => x.GetRequiredService<BotToken>());
        
        services.AddSingleton<RevoltRestClient>();
        services.AddSingleton<IRevoltRestClient>(x => x.GetRequiredService<RevoltRestClient>());
        
        services.AddSingleton<RevoltRestApiClient>();
        services.AddSingleton<IRevoltRestApiClient>(x => x.GetRequiredService<RevoltRestApiClient>());

        services.AddHostedService<TestService>();
    })
    .Build();

try
{
    Log.Information("Hosting started!");
    _ = Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(_ => host.Services.GetServices<IHostedService>());
    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Top-level exception thrown. Hosting has stopped.");
}
finally
{
    host.Dispose();
}