using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using TimeProviderDemo.Timer;

namespace UnitTestProject.Timer;

public class MonitoringServiceRefactoredTests
{
    [Fact]
    public async Task MissedSignalTest()
    {
        // Given
        var timeProvider = new FakeTimeProvider();
        timeProvider.SetUtcNow(new DateTimeOffset(2025, 01, 07, 10, 10, 10, TimeSpan.FromHours(1)));
        var service = new MonitoringServiceRefactored(TimeSpan.FromMinutes(2), timeProvider);
        var called = false;
        service.OnSignalMissed += () => called = true;

        // When
        service.Signal();
        timeProvider.Advance(TimeSpan.FromMinutes(1.9));
        called.Should().BeFalse();
        timeProvider.Advance(TimeSpan.FromMinutes(0.2));

        // Then
        called.Should().BeTrue();
    }
}