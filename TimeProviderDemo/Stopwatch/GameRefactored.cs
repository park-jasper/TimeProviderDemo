namespace TimeProviderDemo.Stopwatch;

public class GameRefactored : IGame
{
    private readonly TimeProvider timeProvider;

    private long startTimestamp;
    private long stopTimestamp;

    public GameRefactored(TimeProvider timeProvider)
    {
        this.timeProvider = timeProvider;
    }

    public void Start()
    {
        startTimestamp = timeProvider.GetTimestamp();
    }

    public void Stop()
    {
        stopTimestamp = timeProvider.GetTimestamp();
    }

    public TimeSpan? TimePlayed => timeProvider.GetElapsedTime(startTimestamp, stopTimestamp);
}