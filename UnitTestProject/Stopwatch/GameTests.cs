using FluentAssertions;
using TimeProviderDemo;
using TimeProviderDemo.Stopwatch;

namespace UnitTestProject.Stopwatch
{
    public class GameTests
    {
        [Fact]
        public async Task StartStop_TimePlayed()
        {
            // Given
            var game = new Game();

            // When
            game.Start();
            await Task.Delay(TimeSpan.FromMilliseconds(200));
            game.Stop();

            // Then
            game.TimePlayed.Should().NotBeNull();
            game.TimePlayed.Should().BeCloseTo(TimeSpan.FromMilliseconds(200), TimeSpan.FromMilliseconds(20));
        }
    }
}