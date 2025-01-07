using System.Text.Json;

namespace TimeProviderDemo.TaskAwait;

public class RequestHandler : IRequestHandler
{
    public const int NumberOfRetries = 5;
    private readonly HttpClient client;
    
    public RequestHandler(HttpClient client)
    {
        this.client = client;
    }

    public async Task<int> RequestNumberOfLines(string key)
    {
        var payload = $$"""
                        {
                          "key": "{{key}}"
                        }
                        """;
        for (int i = 0; i < NumberOfRetries; i += 1)
        {
            try
            {
                var response = await this.client.GetAsync($"https://some.uri/NumberOfLines/{key}");
                var body = await response.Content.ReadAsStreamAsync();
                var responseObject = await JsonSerializer.DeserializeAsync<Response>(body);
                return responseObject.NumberOfLines;
            }
            catch (Exception e)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }

        throw new Exception("Retries failed");
    }

    private record Response(int NumberOfLines);
}