namespace TimeProviderDemo.Timer;

public class MonitoringService : IMonitoringService
{
    private readonly TimeSpan allowedTimeBetweenSignals;
    private readonly ITimer timer;

    public MonitoringService(TimeSpan allowedTimeBetweenSignals)
    {
        this.allowedTimeBetweenSignals = allowedTimeBetweenSignals;
        this.timer = new System.Threading.Timer(
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