using System.Text.Json;
using FluentAssertions;
using TimeProviderDemo.DateTimeNow;

namespace UnitTestProject.DateTimeNow;

public class ReporterTests
{
    [Fact]
    public void ReportValueTest()
    {
        // Given
        var reporter = new Reporter();

        // When
        var jsonReport = reporter.PrintJsonReport();

        // Then
        var now = DateTimeOffset.UtcNow;
        var deserialized = JsonSerializer.Deserialize<ReportJson>(jsonReport);

        deserialized.Title.Should().Be("Some Report");
        deserialized.Content.Should().Be("Some Content");
        deserialized.CreationDate.Should().BeCloseTo(now, TimeSpan.FromMilliseconds(20));
    }

    private record ReportJson(string Title, DateTimeOffset CreationDate, string Content);
}