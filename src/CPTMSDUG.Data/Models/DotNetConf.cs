using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class DotNetConf
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("content_sections")]
    public List<string> ContentSections { get; set; } = new();
}