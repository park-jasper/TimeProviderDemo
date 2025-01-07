namespace TimeProviderDemo.TaskAwait;

public interface IRequestHandler
{
    Task<int> RequestNumberOfLines(string key);
}