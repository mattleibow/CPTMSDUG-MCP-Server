using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Website
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("tagline")]
    public string Tagline { get; set; }
}

