namespace TimeProviderDemo.xFurtherUses;

public class Uses
{
    void CancellationToken()
    {
        var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2), TimeProvider.System);
    }
}