using System.Runtime.CompilerServices;
using Microsoft.Extensions.Time.Testing;
using TimeProviderDemo.DateTimeNow;

namespace UnitTestProject.DateTimeNow;

public class ReporterRefactoredTests
{
    [ModuleInitializer]
    public static void Initializer()
    {
    }

    [Fact]
    public Task VerifyVerify() => VerifyChecks.Run();

    [Fact]
    public void ReportValueTest()
    {
        // Given
        var timeProvider = new FakeTimeProvider();
        timeProvider.SetUtcNow(new DateTimeOffset(2025, 06, 01, 20, 22, 54, TimeSpan.FromHours(1)));
        var reporter = new ReporterRefactored(timeProvider);

        // When
        var jsonReport = reporter.PrintJsonReport();

        // Then
        Verifier.VerifyJson(jsonReport);
    }
}