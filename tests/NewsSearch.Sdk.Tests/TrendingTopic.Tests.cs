using Microsoft.Kiota.Abstractions;
using NewsSearch.Sdk.Models;

namespace NewsSearch.Sdk.Tests;

public class TrendingTopicTests
{
    [Fact]
    public async Task TrendingTopic_GetUS_SuccessAsync()
    {
        // Arrange
        var adapter = Substitute.For<IRequestAdapter>();
        adapter.SetupSendAsyncWithResponse(new TrendingTopics() { Value = [] });

        var newsSearchApiClient = new NewsSearchApiClient(adapter);

        // Act
        var response = await newsSearchApiClient
            .News
            .Trendingtopics
            .GetAsync(r => r.QueryParameters.Cc = "US");

        // Assert
        Assert.NotNull(response);
    }
}