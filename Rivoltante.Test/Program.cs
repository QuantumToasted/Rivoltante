// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rivoltante.Bonfire;
using Rivoltante.Core;
using Rivoltante.Delta;
using Rivoltante.Test;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

var host = new HostBuilder()
    .ConfigureHostConfiguration(x => x.AddEnvironmentVariables("RIVOLTANTE_"))
    .ConfigureLogging((context, logging) =>
    {
        logging.AddSerilog(Log.Logger);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<HttpClient>();

        services.AddSingleton(new JsonSerializerOptions().WithRivoltanteDefaults());
        
        services.AddSingleton(new BotToken(context.Configuration["TOKEN"]!));
        services.AddSingleton<Token>(x => x.GetRequiredService<BotToken>());
        
        services.AddSingleton<RevoltDeltaRateLimiter>();
        services.AddSingleton<IDeltaRateLimiter>(x => x.GetRequiredService<RevoltDeltaRateLimiter>());
        
        services.AddSingleton<RevoltDeltaClient>();
        services.AddSingleton<IDeltaClient>(x => x.GetRequiredService<RevoltDeltaClient>());

        services.AddSingleton<RevoltBonfireEventManager>();
        services.AddSingleton<IBonfireEventManager>(x => x.GetRequiredService<RevoltBonfireEventManager>());
        
        services.AddSingleton<RevoltBonfireClient>();
        services.AddSingleton<IBonfireClient>(x => x.GetRequiredService<RevoltBonfireClient>());

        services.AddSingleton<TestService>();
        services.AddHostedService<TestService>();
    })
    .Build();

try
{
    Log.Information("Hosting started!");
    /*
    _ = Task.Run(async () =>
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        try
        {
            await host.Services.GetRequiredService<TestService>().StartAsync(default);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "uhhh");
        }
    });
    */
    
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