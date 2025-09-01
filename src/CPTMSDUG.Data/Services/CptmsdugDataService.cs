using System.Text.Json;
using CPTMSDUG.Data.Models;

namespace CPTMSDUG.Data.Services;

public interface ICptmsdugDataService
{
    Task<CptmsdugData?> LoadDataAsync(string filePath);
    CptmsdugData? GetCachedData();
    UserGroup? GetUserGroup();
    IReadOnlyList<Event> GetEvents();
    IReadOnlyList<Speaker> GetSpeakers();
    IReadOnlyList<Conference> GetConferences();
    DotNetConf? GetDotNetConf();
    Contact? GetContact();
    Summary? GetSummary();
    Pages? GetPages();
}

public class CptmsdugDataService : ICptmsdugDataService
{
    private CptmsdugData? _cachedData;
    private readonly JsonSerializerOptions _jsonOptions;

    public CptmsdugDataService()
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };
    }

    public async Task<CptmsdugData?> LoadDataAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Data file not found: {filePath}");
        }

        var jsonContent = await File.ReadAllTextAsync(filePath);
        _cachedData = JsonSerializer.Deserialize<CptmsdugData>(jsonContent, _jsonOptions);
        return _cachedData;
    }

    public CptmsdugData? GetCachedData() => _cachedData;

    public UserGroup? GetUserGroup() => _cachedData?.UserGroup;

    public IReadOnlyList<Event> GetEvents() => _cachedData?.Events?.AsReadOnly() ?? new List<Event>().AsReadOnly();

    public IReadOnlyList<Speaker> GetSpeakers() => _cachedData?.Speakers?.AsReadOnly() ?? new List<Speaker>().AsReadOnly();

    public IReadOnlyList<Conference> GetConferences() => _cachedData?.Conferences?.AsReadOnly() ?? new List<Conference>().AsReadOnly();

    public DotNetConf? GetDotNetConf() => _cachedData?.DotNetConf;

    public Contact? GetContact() => _cachedData?.Contact;

    public Summary? GetSummary() => _cachedData?.Summary;

    public Pages? GetPages() => _cachedData?.Pages;
}