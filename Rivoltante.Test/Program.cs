﻿using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Rivoltante.Bonfire;
using Rivoltante.Core;
using Rivoltante.Rest;
using Rivoltante.Test;
using Serilog;

var host = new HostBuilder()
    .ConfigureHostConfiguration(x => x.AddEnvironmentVariables("RIVOLTANTE_"))
    .UseSerilog((context, logger) =>
    {
        logger.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}");
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<HttpClient>();
        
        services.AddSingleton<RevoltRestRateLimitHandler>();
        services.AddSingleton<IRevoltRestRateLimitHandler>(x => x.GetRequiredService<RevoltRestRateLimitHandler>());

        services.AddSingleton(new JsonSerializerOptions
        {
            Converters =
            {
                new UlidJsonConverter(),
                new OptionalJsonConverter(),
                new JsonStringEnumConverter()
            },
            TypeInfoResolver = new OptionalJsonTypeInfoResolver()
        });
        
        //services.AddSingleton<JsonSerializer>();

        var token = new BotToken(context.Configuration["TOKEN"]!);
        services.AddSingleton(token);
        services.AddSingleton<Token>(x => x.GetRequiredService<BotToken>());
        
        services.AddSingleton<RevoltRestClient>();
        services.AddSingleton<IRevoltRestClient>(x => x.GetRequiredService<RevoltRestClient>());
        
        services.AddSingleton<RevoltRestApiClient>();
        services.AddSingleton<IRevoltRestApiClient>(x => x.GetRequiredService<RevoltRestApiClient>());

        services.AddSingleton<RevoltWebSocketClientFactory>();
        services.AddSingleton<IWebSocketClientFactory>(x => x.GetRequiredService<RevoltWebSocketClientFactory>());

        services.AddSingleton<RevoltBonfireConnection>();
        services.AddSingleton<IBonfireConnection>(x => x.GetRequiredService<RevoltBonfireConnection>());

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