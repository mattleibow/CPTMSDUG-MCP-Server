using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class SpeakingOpportunities
{
    [JsonPropertyName("callForSpeakers")]
    public bool CallForSpeakers { get; set; }

    [JsonPropertyName("sessionizeUrl")]
    public string SessionizeUrl { get; set; } = string.Empty;

    [JsonPropertyName("contactEmail")]
    public string ContactEmail { get; set; } = string.Empty;

    [JsonPropertyName("welcomedTopics")]
    public List<string> WelcomedTopics { get; set; } = new();

    [JsonPropertyName("speakerBenefits")]
    public List<string> SpeakerBenefits { get; set; } = new();

    [JsonPropertyName("experienceLevels")]
    public string ExperienceLevels { get; set; } = string.Empty;
}

