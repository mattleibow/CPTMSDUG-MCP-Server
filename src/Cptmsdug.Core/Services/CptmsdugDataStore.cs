using System.Text.Json;
using Cptmsdug.Core.Models;

namespace Cptmsdug.Core.Services;

public class CptmsdugDataStore
{
    private readonly HttpClient _httpClient;
    private readonly string _dataUrl = "https://cptmsdug.dev/mcp.json";
    private readonly Task<CptmsdugMcpData> _dataTask;
    private readonly JsonSerializerOptions _jsonOptions;

    public CptmsdugDataStore(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            TypeInfoResolver = CptmsdugMcpDataJsonContext.Default
        };

        // Start loading data immediately in constructor for fast startup
        _dataTask = LoadDataAsync();
    }

    private async Task<CptmsdugMcpData> LoadDataAsync()
    {
        var response = await _httpClient.GetAsync(_dataUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize(json, CptmsdugMcpDataJsonContext.Default.CptmsdugMcpData);

        return data ?? new CptmsdugMcpData();
    }

    public async Task<CptmsdugMcpData> GetDataAsync()
    {
        return await _dataTask;
    }

    public async Task<CommunityStats> GetCommunityStatsAsync()
    {
        var data = await _dataTask;
        return data.CommunityStats;
    }

    public async Task<List<Event>> GetUpcomingEventsAsync()
    {
        var data = await _dataTask;
        return data.Events.AllEvents
            .Where(e => e.IsUpcoming)
            .OrderBy(e => e.StartTime)
            .ToList();
    }

    public async Task<List<Event>> GetPastEventsAsync()
    {
        var data = await _dataTask;
        return data.Events.AllEvents
            .Where(e => e.IsPast)
            .OrderByDescending(e => e.StartTime)
            .ToList();
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

    public async Task<CommunityInformation> GetOrganizationAsync()
    {
        var data = await _dataTask;
        return data.Organization;
    }

    public async Task<Contact> GetContactAsync()
    {
        var data = await _dataTask;
        return data.Contact;
    }

    public async Task<CommunityTechnologies> GetTechnologiesAsync()
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

    public async Task<CommunitySpeakerStatistics> GetSpeakerStatisticsAsync()
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
