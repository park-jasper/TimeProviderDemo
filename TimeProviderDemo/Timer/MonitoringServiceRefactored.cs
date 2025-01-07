namespace TimeProviderDemo.Timer;

public class MonitoringServiceRefactored
{
    private readonly TimeSpan allowedTimeBetweenSignals;
    private readonly TimeProvider timeProvider;
    private readonly ITimer timer;

    public MonitoringServiceRefactored(TimeSpan allowedTimeBetweenSignals, TimeProvider timeProvider)
    {
        this.allowedTimeBetweenSignals = allowedTimeBetweenSignals;
        this.timeProvider = timeProvider;
        this.timer = this.timeProvider.CreateTimer(
            _ => this.OnSignalMissed?.Invoke(),
            null,
            Timeout.InfiniteTimeSpan,
            Timeout.InfiniteTimeSpan);
    }

    public event Action? OnSignalMissed;

    public void Signal()
    {
        this.timer.Change(this.allowedTimeBetweenSignals, Timeout.InfiniteTimeSpan);
    }

    public void StopMonitoring()
    {
        this.timer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
    }
}