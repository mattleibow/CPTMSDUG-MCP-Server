using System.Text.Json;
using CPTMSDUG.Data.Models;

namespace CPTMSDUG.Data.Services;

public interface ICptmsdugDataService
{
    Task<CptmsdugData?> LoadDataAsync(string urlOrPath);
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
    private readonly HttpClient _httpClient;

    public CptmsdugDataService(HttpClient? httpClient = null)
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };
        _httpClient = httpClient ?? new HttpClient();
    }

    public async Task<CptmsdugData?> LoadDataAsync(string urlOrPath)
    {
        string jsonContent;

        if (IsUrl(urlOrPath))
        {
            // Load from URL
            var response = await _httpClient.GetAsync(urlOrPath);
            response.EnsureSuccessStatusCode();
            jsonContent = await response.Content.ReadAsStringAsync();
        }
        else
        {
            // Load from file path
            if (!File.Exists(urlOrPath))
            {
                throw new FileNotFoundException($"Data file not found: {urlOrPath}");
            }
            jsonContent = await File.ReadAllTextAsync(urlOrPath);
        }

        _cachedData = JsonSerializer.Deserialize<CptmsdugData>(jsonContent, _jsonOptions);
        return _cachedData;
    }

    private static bool IsUrl(string input)
    {
        return Uri.TryCreate(input, UriKind.Absolute, out var uri) 
               && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
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