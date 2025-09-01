using System.Text.Json;
using CPTMSDUG.Data.Models;

namespace CPTMSDUG.Data;

public class CPTMSDUGDataStore
{
    private readonly string _dataDirectory;
    private readonly JsonSerializerOptions _jsonOptions;

    public List<Event> Events { get; private set; } = new();
    public List<Conference> Conferences { get; private set; } = new();
    public List<Speaker> Speakers { get; private set; } = new();
    public General? General { get; private set; }
    public Metadata? Metadata { get; private set; }

    public CPTMSDUGDataStore(string dataDirectory)
    {
        _dataDirectory = dataDirectory;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };
    }

    public async Task LoadAllDataAsync()
    {
        await LoadEventsAsync();
        await LoadConferencesAsync();
        await LoadSpeakersAsync();
        await LoadGeneralAsync();
        await LoadMetadataAsync();
    }

    public async Task LoadEventsAsync()
    {
        var filePath = Path.Combine(_dataDirectory, "events.json");
        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            Events = JsonSerializer.Deserialize<List<Event>>(json, _jsonOptions) ?? new();
        }
    }

    public async Task LoadConferencesAsync()
    {
        var filePath = Path.Combine(_dataDirectory, "conferences.json");
        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            Conferences = JsonSerializer.Deserialize<List<Conference>>(json, _jsonOptions) ?? new();
        }
    }

    public async Task LoadSpeakersAsync()
    {
        var filePath = Path.Combine(_dataDirectory, "speakers.json");
        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            Speakers = JsonSerializer.Deserialize<List<Speaker>>(json, _jsonOptions) ?? new();
        }
    }

    public async Task LoadGeneralAsync()
    {
        var filePath = Path.Combine(_dataDirectory, "general.json");
        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            General = JsonSerializer.Deserialize<General>(json, _jsonOptions);
        }
    }

    public async Task LoadMetadataAsync()
    {
        var filePath = Path.Combine(_dataDirectory, "metadata.json");
        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            Metadata = JsonSerializer.Deserialize<Metadata>(json, _jsonOptions);
        }
    }

    // Query methods for convenience
    public IEnumerable<Event> GetUpcomingEvents()
    {
        return Events.Where(e => e.Type == "meetup" || e.Type == "conference");
    }

    public IEnumerable<Event> GetMeetups()
    {
        return Events.Where(e => e.Type == "meetup");
    }

    public IEnumerable<Event> GetConferenceEvents()
    {
        return Events.Where(e => e.Type == "conference");
    }

    public IEnumerable<Speaker> GetSpeakersByExpertise(string expertise)
    {
        return Speakers.Where(s => s.Expertise.Contains(expertise, StringComparer.OrdinalIgnoreCase));
    }

    public Speaker? GetSpeakerByName(string name)
    {
        return Speakers.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Conference? GetConferenceByName(string name)
    {
        return Conferences.FirstOrDefault(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<string> GetAllExpertiseAreas()
    {
        return Speakers.SelectMany(s => s.Expertise).Distinct().OrderBy(e => e);
    }

    public IEnumerable<string> GetAllTechnologies()
    {
        return General?.TechnologiesFocus?.Select(t => t.Name) ?? Enumerable.Empty<string>();
    }

    public int GetTotalMemberCount()
    {
        if (General?.Statistics?.TotalMembers != null && 
            int.TryParse(General.Statistics.TotalMembers.Replace(",", ""), out int count))
        {
            return count;
        }
        return 0;
    }
}