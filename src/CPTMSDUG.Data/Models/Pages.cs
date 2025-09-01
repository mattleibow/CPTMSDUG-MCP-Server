using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Pages
{
    [JsonPropertyName("homepage")]
    public PageInfo Homepage { get; set; } = new();

    [JsonPropertyName("about")]
    public PageInfo About { get; set; } = new();

    [JsonPropertyName("meetups")]
    public PageInfo Meetups { get; set; } = new();

    [JsonPropertyName("speakers")]
    public PageInfo Speakers { get; set; } = new();

    [JsonPropertyName("conferences")]
    public PageInfo Conferences { get; set; } = new();

    [JsonPropertyName("dotnet-conf-2025")]
    public PageInfo DotNetConf2025 { get; set; } = new();

    [JsonPropertyName("contact")]
    public PageInfo Contact { get; set; } = new();
}

public class PageInfo
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}