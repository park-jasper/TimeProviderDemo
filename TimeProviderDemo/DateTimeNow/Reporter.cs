using System.Text.Json;
using System.Text.Json.Serialization;

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