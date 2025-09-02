using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class WebsitePage
{
    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("file")]
    public string File { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

