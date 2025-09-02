using System.Text.Json;
using Cptmsdug.Core.Models;

namespace Cptmsdug.Core.Services;

public class CptmsdugDataStore
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
            WriteIndented = true,
            TypeInfoResolver = CptmsdugJsonContext.Default
        };

        // Start loading data immediately in constructor for fast startup
        _dataTask = LoadDataAsync();
    }

    private async Task<CptmsdugData> LoadDataAsync()
    {
        var response = await _httpClient.GetAsync(_dataUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize(json, CptmsdugJsonContext.Default.CptmsdugData);

        return data ?? new CptmsdugData();
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

    public async Task<List<EventUpcoming>> GetUpcomingEventsAsync()
    {
        var data = await _dataTask;
        return data.Events.UpcomingEvents;
    }

    public async Task<List<EventPast>> GetPastEventsAsync()
    {
        var data = await _dataTask;
        return data.Events.PastEvents;
    }

    public async Task<List<EventSpeaker>> GetSpeakersAsync()
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

    public async Task<Website> GetWebsiteAsync()
    {
        var data = await _dataTask;
        return data.Website;
    }

    public async Task<Opportunities> GetOpportunitiesAsync()
    {
        var data = await _dataTask;
        return data.Opportunities;
    }

    public async Task<SpeakerStatistics> GetSpeakerStatisticsAsync()
    {
        var data = await _dataTask;
        return data.SpeakerStatistics;
    }

    public async Task<bool> IsDataLoadedAsync()
    {
        try
        {
            var data = await _dataTask;
            return !string.IsNullOrEmpty(data.Name);
        }
        catch
        {
            return false;
        }
    }
}