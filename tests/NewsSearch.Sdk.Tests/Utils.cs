using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;

namespace NewsSearch.Sdk.Tests;

public static class Utils
{
    public static void SetupSendAsyncWithResponse<T>(
        this IRequestAdapter adapter, T response) where T : IParsable
    {
        adapter.SendAsync<T>(
            Arg.Any<RequestInformation>(),
            Arg.Any<ParsableFactory<T>>(),
            Arg.Any<Dictionary<string, ParsableFactory<IParsable>>>(),
            Arg.Any<CancellationToken>())
            .ReturnsForAnyArgs(response);
    }
}