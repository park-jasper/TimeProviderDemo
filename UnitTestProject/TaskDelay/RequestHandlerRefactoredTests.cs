using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using RichardSzalay.MockHttp;
using TimeProviderDemo.TaskAwait;

namespace UnitTestProject.TaskDelay;

public class RequestHandlerRefactoredTests
{
    [Fact]
    public async Task RequestFails_RetriesFailEventually()
    {
        // Given
        var http = new MockHttpMessageHandler();
        var timeProvider = new FakeTimeProvider();
        timeProvider.SetUtcNow(new DateTimeOffset(2025, 07, 01, 09, 17, 27, TimeSpan.FromHours(1)));
        var requestHandler = new RequestHandlerRefactored(http.ToHttpClient(), timeProvider);

        // When
        var action = () => requestHandler.RequestNumberOfLines("SomeKey");
        var assertion = action.Should().ThrowAsync<Exception>();

        // Then
        for (int i = 0; i < RequestHandlerRefactored.NumberOfRetries; i += 1)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(5));
            timeProvider.Advance(TimeSpan.FromSeconds(3));
        }

        var exception = (await assertion).Which;
        exception.Message.Should().Contain("Retries");

    }
}