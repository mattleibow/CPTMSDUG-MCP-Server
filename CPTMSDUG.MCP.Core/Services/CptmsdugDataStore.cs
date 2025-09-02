using System.Text.Json;
using CPTMSDUG.MCP.Core.Models;

namespace CPTMSDUG.MCP.Core.Services;

public interface ICptmsdugDataStore
{
    Task<CptmsdugData> GetDataAsync();
    Task<CommunityStats> GetCommunityStatsAsync();
    Task<List<UpcomingEvent>> GetUpcomingEventsAsync();
    Task<List<Speaker>> GetSpeakersAsync();
    Task<List<Organizer>> GetOrganizersAsync();
    Task<Organization> GetOrganizationAsync();
    Task<Contact> GetContactAsync();
    Task<Technologies> GetTechnologiesAsync();
    Task<Mission> GetMissionAsync();
}

public class CptmsdugDataStore : ICptmsdugDataStore
{
    private readonly HttpClient _httpClient;
    private readonly string _dataUrl = "https://cptmsdug.dev/mcp.json";
    private readonly Task<CptmsdugData> _dataTask;
    private readonly JsonSerializerOptions _jsonOptions;

    public CptmsdugDataStore(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        // Start loading data immediately in constructor for fast startup
        _dataTask = LoadDataAsync();
    }

    private async Task<CptmsdugData> LoadDataAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(_dataUrl);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<CptmsdugData>(json, _jsonOptions);
            
            return data ?? new CptmsdugData();
        }
        catch (Exception ex)
        {
            // Log the exception in a real application
            Console.WriteLine($"Error loading CPTMSDUG data: {ex.Message}");
            return new CptmsdugData();
        }
    }

    public async Task<CptmsdugData> GetDataAsync()
    {
        return await _dataTask;
    }

    public async Task<CommunityStats> GetCommunityStatsAsync()
    {
        var data = await _dataTask;
        return data.CommunityStats;
    }

    public async Task<List<UpcomingEvent>> GetUpcomingEventsAsync()
    {
        var data = await _dataTask;
        return data.Events.UpcomingEvents;
    }

    public async Task<List<Speaker>> GetSpeakersAsync()
    {
        var data = await _dataTask;
        return data.Speakers;
    }

    public async Task<List<Organizer>> GetOrganizersAsync()
    {
        var data = await _dataTask;
        return data.Organizers;
    }

    public async Task<Organization> GetOrganizationAsync()
    {
        var data = await _dataTask;
        return data.Organization;
    }

    public async Task<Contact> GetContactAsync()
    {
        var data = await _dataTask;
        return data.Contact;
    }

    public async Task<Technologies> GetTechnologiesAsync()
    {
        var data = await _dataTask;
        return data.Technologies;
    }

    public async Task<Mission> GetMissionAsync()
    {
        var data = await _dataTask;
        return data.Mission;
    }
}