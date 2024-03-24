using App.Sdk;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var services = builder.Services;

RegisterAppApiClient(services);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultEndpoints();

app.MapGet("/my/trending", async (AppApiClient client) =>
{
    var response = await client.Trending["US"].GetAsync();

    return response.Value.Select(topic => topic.Query.Text);
});

app.Run();

static void RegisterAppApiClient(IServiceCollection services)
{
    services.AddHttpClient<AppApiClient>().AddTypedClient(httpClient =>
    {
        var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
        {
            BaseUrl = "http://app"
        };

        return new AppApiClient(requestAdapter);
    }).ConfigurePrimaryHttpMessageHandler(_ =>
    {
        IList<DelegatingHandler> defaultHandlers = KiotaClientFactory.CreateDefaultHandlers();
        HttpMessageHandler defaultHttpMessageHandler = KiotaClientFactory.GetDefaultHttpMessageHandler();

        return KiotaClientFactory.ChainHandlersCollectionAndGetFirstLink(
            defaultHttpMessageHandler, [.. defaultHandlers])!;
    });
}