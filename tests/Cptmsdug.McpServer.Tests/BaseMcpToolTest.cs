namespace Cptmsdug.McpServer.Tests;

public abstract class BaseMcpToolTest<T> : IDisposable
{
    protected readonly HttpClient HttpClient;
    protected readonly CptmsdugDataStore DataStore;
    protected readonly T Tool;

    protected BaseMcpToolTest()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        HttpClient = new HttpClient(handler);
        DataStore = new CptmsdugDataStore(HttpClient);
        Tool = CreateTool();
    }

    /// <summary>
    /// Creates an instance of the tool being tested
    /// </summary>
    protected abstract T CreateTool();

    public void Dispose()
    {
        HttpClient?.Dispose();
    }
}