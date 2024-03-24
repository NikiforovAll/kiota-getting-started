using Microsoft.Extensions.Http.Resilience;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using NewsSearch.Sdk;
using static Microsoft.Kiota.Abstractions.Authentication.ApiKeyAuthenticationProvider;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var services = builder.Services;

RegisterNewsSearchApiClient(services);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultEndpoints();
app.MapTrendingEndpoints();

app.Run();

static void RegisterNewsSearchApiClient(IServiceCollection services)
{
    services.AddSingleton<IAuthenticationProvider, ApiKeyAuthenticationProvider>(sp =>
    {
        var apiKey = sp.GetRequiredService<IConfiguration>()["ApiKey"]!;

        return new(apiKey, "Ocp-Apim-Subscription-Key", KeyLocation.Header);
    });

    services.AddHttpClient<NewsSearchApiClient>()
    .AddTypedClient((httpClient, sp) =>
    {
        var authenticationProvider = sp.GetRequiredService<IAuthenticationProvider>();
        var requestAdapter = new HttpClientRequestAdapter(authenticationProvider, httpClient: httpClient)
        {
            BaseUrl = "https://api.bing.microsoft.com/v7.0"
        };

        return new NewsSearchApiClient(requestAdapter);
    })
    .ConfigurePrimaryHttpMessageHandler(_ =>
    {
        IList<DelegatingHandler> defaultHandlers = KiotaClientFactory.CreateDefaultHandlers();
        HttpMessageHandler defaultHttpMessageHandler = KiotaClientFactory.GetDefaultHttpMessageHandler();

        // Or, if your generated client is long-lived, respond to DNS updates using:
        // HttpMessageHandler defaultHttpMessageHandler = new SocketsHttpHandler();

        return KiotaClientFactory.ChainHandlersCollectionAndGetFirstLink(
            defaultHttpMessageHandler, [.. defaultHandlers])!;
    })
    .AddStandardResilienceHandler().Configure(cfg =>
    {
        cfg.Retry.MaxRetryAttempts = 3;
        cfg.Retry.UseJitter = true;
        cfg.Retry.BackoffType = Polly.DelayBackoffType.Exponential;
    });
}