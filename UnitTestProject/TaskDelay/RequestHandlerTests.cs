using FluentAssertions;
using RichardSzalay.MockHttp;
using TimeProviderDemo.TaskAwait;

namespace UnitTestProject.TaskDelay;

public class RequestHandlerTests
{
    [Fact]
    public async Task RequestFails_RetriesFailEventually()
    {
        // Given
        var http = new MockHttpMessageHandler();
        var requestHandler = new RequestHandler(http.ToHttpClient());

        // When
        var action = () => requestHandler.RequestNumberOfLines("SomeKey");
        
        // Then
        (await action.Should().ThrowAsync<Exception>()).Which.Message.Should().Contain("Retries");
    }
}