using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NewsSearch.Sdk;
using NewsSearch.Sdk.Models;

public static class GetTrendingTopicsEndpoint
{
    public static Task<Results<Ok<TrendingTopics>, BadRequest<ProblemDetails>>> GetTrendingTopics(
        NewsSearchApiClient newsSearchApiClient) =>
            GetTrendingTopicsByCountry(newsSearchApiClient, default);

    public static async Task<Results<Ok<TrendingTopics>, BadRequest<ProblemDetails>>> GetTrendingTopicsByCountry(
        NewsSearchApiClient newsSearchApiClient, string? country)
    {
        var response = await newsSearchApiClient.News.Trendingtopics.GetAsync(
            r => r.QueryParameters.Cc = country);

        return TypedResults.Ok(response);
    }
}
