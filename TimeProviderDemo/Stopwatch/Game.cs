using System.Diagnostics;

namespace TimeProviderDemo.Stopwatch;

public class Game : IGame
{
    private System.Diagnostics.Stopwatch? sw;

    public void Start()
    {
        sw = new();
        sw.Start();
    }

    public void Stop()
    {
        sw.Stop();
    }

    public TimeSpan? TimePlayed => sw?.Elapsed;
}