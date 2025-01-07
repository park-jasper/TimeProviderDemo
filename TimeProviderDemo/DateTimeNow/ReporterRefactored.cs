using System.Text.Json;

namespace TimeProviderDemo.DateTimeNow;

public class ReporterRefactored : IReporting
{
    private readonly TimeProvider timeProvider;

    public ReporterRefactored(TimeProvider timeProvider)
    {
        this.timeProvider = timeProvider;
    }

    public string PrintJsonReport()
    {
        var content = new ReportJson("Some Report", this.timeProvider.GetLocalNow(), "Some Content");
        return JsonSerializer.Serialize(content);
    }

    private record ReportJson(string Title, DateTimeOffset CreationDate, string Content);
}