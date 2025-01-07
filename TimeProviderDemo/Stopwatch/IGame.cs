namespace TimeProviderDemo.Stopwatch;

public interface IGame
{
    void Start();

    void Stop();

    TimeSpan? TimePlayed { get; }
}