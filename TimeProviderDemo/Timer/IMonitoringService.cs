namespace TimeProviderDemo.Timer;

public interface IMonitoringService
{
    event Action? OnSignalMissed;

    void Signal();

    void StopMonitoring();
}