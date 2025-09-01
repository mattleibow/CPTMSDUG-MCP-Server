using System.Text.Json;
using CPTMSDUG.Data.Models;

namespace CPTMSDUG.Data.Services;

public interface ICptmsdugDataService
{
    Task<UserGroup?> GetUserGroupAsync();
    Task<IReadOnlyList<Event>> GetEventsAsync();
    Task<IReadOnlyList<Speaker>> GetSpeakersAsync();
    Task<IReadOnlyList<Conference>> GetConferencesAsync();
    Task<DotNetConf?> GetDotNetConfAsync();
    Task<Contact?> GetContactAsync();
    Task<Summary?> GetSummaryAsync();
    Task<Pages?> GetPagesAsync();
}

public class CptmsdugDataService : ICptmsdugDataService
{
    private readonly Task<CptmsdugData?> _loadDataTask;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly HttpClient _httpClient;

    public CptmsdugDataService(string dataUrl, HttpClient? httpClient = null)
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };
        _httpClient = httpClient ?? new HttpClient();
        
        // Start loading data immediately in the background
        _loadDataTask = LoadDataInternalAsync(dataUrl);
    }

    private async Task<CptmsdugData?> LoadDataInternalAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CptmsdugData>(jsonContent, _jsonOptions);
    }

    public async Task<UserGroup?> GetUserGroupAsync()
    {
        var data = await _loadDataTask;
        return data?.UserGroup;
    }

    public async Task<IReadOnlyList<Event>> GetEventsAsync()
    {
        var data = await _loadDataTask;
        return data?.Events?.AsReadOnly() ?? new List<Event>().AsReadOnly();
    }

    public async Task<IReadOnlyList<Speaker>> GetSpeakersAsync()
    {
        var data = await _loadDataTask;
        return data?.Speakers?.AsReadOnly() ?? new List<Speaker>().AsReadOnly();
    }

    public async Task<IReadOnlyList<Conference>> GetConferencesAsync()
    {
        var data = await _loadDataTask;
        return data?.Conferences?.AsReadOnly() ?? new List<Conference>().AsReadOnly();
    }

    public async Task<DotNetConf?> GetDotNetConfAsync()
    {
        var data = await _loadDataTask;
        return data?.DotNetConf;
    }

    public async Task<Contact?> GetContactAsync()
    {
        var data = await _loadDataTask;
        return data?.Contact;
    }

    public async Task<Summary?> GetSummaryAsync()
    {
        var data = await _loadDataTask;
        return data?.Summary;
    }

    public async Task<Pages?> GetPagesAsync()
    {
        var data = await _loadDataTask;
        return data?.Pages;
    }
}