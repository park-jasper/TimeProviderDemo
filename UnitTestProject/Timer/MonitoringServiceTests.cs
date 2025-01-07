using FluentAssertions;
using TimeProviderDemo.Timer;

namespace UnitTestProject.Timer;

public class MonitoringServiceTests
{
    [Fact]
    public async Task MissedSignalTest()
    {
        // Given
        var service = new MonitoringService(TimeSpan.FromMilliseconds(5));
        var called = false;
        service.OnSignalMissed += () => called = true;

        // When
        service.Signal();
        await Task.Delay(TimeSpan.FromMilliseconds(10));

        // Then
        called.Should().BeTrue();
    }
}