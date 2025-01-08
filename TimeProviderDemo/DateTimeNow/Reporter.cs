using System.Text.Json;

namespace TimeProviderDemo.DateTimeNow;

public class Reporter : IReporting
{
    public string PrintJsonReport()
    {
        var content = new ReportJson("Some Report", DateTimeOffset.Now, "Some Content");
        return JsonSerializer.Serialize(content);
    }

    private record ReportJson(string Title, DateTimeOffset CreationDate, string Content);
}