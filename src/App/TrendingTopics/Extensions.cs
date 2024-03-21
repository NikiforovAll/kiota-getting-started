namespace Microsoft.Extensions.Hosting;

public static class Extensions
{
    public static WebApplication MapTrendingEndpoints(this WebApplication app)
    {
        app
            .MapGroup("/trending")
            .MapTrendingEndpoints()
            .WithTags("Trending Topics")
            .AllowAnonymous();

        return app;
    }

    public static RouteGroupBuilder MapTrendingEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("", GetTrendingTopicsEndpoint.GetTrendingTopics)
            .WithName(nameof(GetTrendingTopicsEndpoint.GetTrendingTopics));
        
        group.MapGet("{country:minlength(2):maxlength(2)}", GetTrendingTopicsEndpoint.GetTrendingTopicsByCountry)
            .WithName(nameof(GetTrendingTopicsEndpoint.GetTrendingTopicsByCountry));

        return group;
    }
}
