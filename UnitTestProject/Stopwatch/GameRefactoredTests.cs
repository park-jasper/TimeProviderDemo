using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using TimeProviderDemo;
using TimeProviderDemo.Stopwatch;

namespace UnitTestProject.Stopwatch;

public class GameRefactoredTests
{
    [Fact]
    public void StartStop_TimePlayed()
    {
        // Given
        var timeProvider = new FakeTimeProvider();
        timeProvider.SetUtcNow(new DateTimeOffset(2025, 06, 01, 20, 08, 18, TimeSpan.FromHours(1)));
        var game = new GameRefactored(timeProvider);

        // When
        game.Start();
        timeProvider.Advance(TimeSpan.FromMinutes(38));
        game.Stop();

        // Then
        game.TimePlayed.Should().NotBeNull();
        game.TimePlayed.Should().Be(TimeSpan.FromMinutes(38));
    }
}